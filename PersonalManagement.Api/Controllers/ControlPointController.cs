using Microsoft.AspNetCore.Mvc;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Repositories.Contracts;
using PersonalManagement.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlPointController : Controller
    {
        private readonly IControlPointRepository _controlPointRepository;
        public ControlPointController(IControlPointRepository controlPointRepository)
        {
            _controlPointRepository = controlPointRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index([FromQuery] ControlPointViewModel controlPointViewModel)
        {
            try
            {
                var controlPoints = await _controlPointRepository.GetAll(controlPointViewModel);
                return Ok(controlPoints);
            } catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ControlPoint controlPoint)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Por favor preencha os dados corretamente!");
                }
                await _controlPointRepository.Create(controlPoint);
                return Ok(new { mensage = "Cadastrado com sucesso!" });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
    }
}
