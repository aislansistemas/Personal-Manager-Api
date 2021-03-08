using PersonalManagement.Api.Models;
using PersonalManagement.Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Contracts
{
    public interface IAccountRepository
    {
         Task<UserAccount> GetUserByEmail(string email);
         Task<UserAccount> CadastrarUsuario(UserAccount user, string roleName);
         Task CadastraRoles(string roleName);
         Task<bool> PasswordIsValid(UserAccount usuario, string password);
         Task<IList<UserAccount>> GetAll(int numberPage, int limit);
         Task Atualizar(UserAccount usuario);
        
    }
}