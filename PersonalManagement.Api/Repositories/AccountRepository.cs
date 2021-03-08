using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalManagement.Api.Context;
using PersonalManagement.Api.Contracts;
using PersonalManagement.Api.Exceptions;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.ViewModel;

namespace PersonalManagement.Api.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManeger;
        private readonly PersonalManagerContext _context;

        public AccountRepository(
            UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManeger,
            PersonalManagerContext context
        ){
            _userManager = userManager;
            _roleManeger = roleManeger;
            _context = context;
        } 
        public async Task CadastraRoles(string roleName)
        {
            try {
                if(roleName != null){
                    await _roleManeger.CreateAsync(new IdentityRole(roleName));
                }
            } catch(Exception) {
                throw new CreatedException("Não foi possível realizar o cadastro.");
            }
        }

        public async Task<UserAccount> CadastrarUsuario(
            UserAccount user, 
            string roleName
        ) {
            try {
                user.Role = roleName;
                var result = await _userManager.CreateAsync(user, user.PasswordHash);

                if(!result.Succeeded){
                    throw new CreatedException("Erro ao tentar cadastrar um novo usuario");
                }

                //await this.SetRoleForUsuario(user, roleName);
                return user;
            } catch(Exception e) {
                throw new CreatedException(e.Message);
            }
        }
    
        private async Task SetRoleForUsuario(UserAccount usuario, string roleName) 
        {
            try {
                var roleResult = await _roleManeger.FindByNameAsync(roleName);
                if(roleResult == null){
                    await _roleManeger.CreateAsync(new IdentityRole(roleName));
                }
                await _userManager.AddToRoleAsync(usuario, roleName);
            } catch(Exception) {
                throw new CreatedException("Erro ao tentar cadastrar um novo usuario");
            }
        }   

        public async Task<bool> PasswordIsValid(UserAccount usuario, string password) 
        {
            bool result = await _userManager.CheckPasswordAsync(usuario, password);
            return result;
        }

        public async Task<UserAccount> GetUserByEmail(string email)
        {
            try{
                return await _userManager.FindByNameAsync(email);
            } catch(Exception) {
                throw new NotFoundException("Erro ao procurar email");
            }
        }

        public async Task<IList<UserAccount>> GetAll(int numberPage, int limit)
        {
            try {
                var usuarios = await _context.Users
                .AsNoTrackingWithIdentityResolution()
                .OrderByDescending(x => x.Id)
                .Skip((numberPage - 1) * limit)
                .Take(limit)
                .ToListAsync();

                return (IList<UserAccount>)usuarios;

            } catch(Exception) {
                throw new NotFoundException("Nenhum usuario encontrado.");
            }   
        }

        public async Task Atualizar(UserAccount usuario)
        {
            try{
                UserAccount user = new UserAccount(){
                    UserName = usuario.UserName, 
                };
                await _userManager.UpdateAsync(usuario);
            } catch (DbUpdateConcurrencyException) {
                throw new DbConcurrencyException("Não foi possível atualizar o Usuário.");
            }   
        }
    }
}