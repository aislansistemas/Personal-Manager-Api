using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalManagement.Api.Contracts;
using PersonalManagement.Api.Enums;
using PersonalManagement.Api.Exceptions;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<UserAccount> _signInManager;
        public AccountController(
            IAccountRepository accountRepository,
            SignInManager<UserAccount> signManager
        )
        {
            _accountRepository = accountRepository;
            _signInManager = signManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserAccount userAccount)
        {
            try
            {
                var userResult = await _accountRepository.GetUserByEmail(userAccount.UserName);
                if (userResult == null)
                    throw new NotFoundException("Usuário não encontrado !");

                if (!await _accountRepository.PasswordIsValid(userResult, userAccount.PasswordHash))
                    throw new InvalidArgumentException("Usuário Inválido !");

                var token = TokenService.GenerateToken(userResult);
                
                return Ok(new { mensage = token });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<IActionResult> CreateUser([FromBody] UserAccount userAccount)
        {
            try
            {
                var usuarioIsExistente = await _accountRepository.GetUserByEmail(userAccount.UserName);

                if (usuarioIsExistente != null)
                    throw new InvalidArgumentException("Desculpe Já existente um úsuario cadastrado com o mesmo e-mail!");

                var usuarioCadastrado = await _accountRepository.CadastrarUsuario(userAccount, UserRoleEnum.Comun);

                return Ok(new { mensage = "Usuario Cadastrado com sucesso!" });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Menber")]
        public string Employee() => "Funcionário";
    }
}
