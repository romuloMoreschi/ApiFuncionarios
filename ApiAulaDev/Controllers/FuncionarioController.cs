using System;
using ApiAulaDev.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiAulaDev.Repositorio.Interfaces;

namespace ApiAulaDev.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IBaseRepositorio<Funcionario> _baseRepositorio;
        public FuncionarioController(IBaseRepositorio<Funcionario> baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        [HttpPost]
        [Route("/api/v1/funcionarios/create")]
        public async Task<IActionResult> Create([FromBody] Funcionario funcionario)
        {
            try
            {
                return Ok(new 
                { 
                    Message = "Usuário cadastrado com sucesso !",
                    Success = true,
                    Data = await _baseRepositorio.Create(funcionario)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpGet]
        [Route("/api/v1/funcionarios/get-funcionarios")]
        public async Task<IActionResult> GetFuncionarios()
        {
            try
            {
                return Ok(await _baseRepositorio.Get());
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro !");
            }
        }

        [HttpPut]
        [Route("/api/v1/funcionarios/update")]
        public async Task<IActionResult> Update([FromBody] Funcionario funcionario, int id)
        {
            try
            {
                if (id != funcionario.Id)
                {
                    return BadRequest();
                }

                return Ok(new
                {
                    Message = "Usuário atualizado com sucesso !",
                    Success = true,
                    data = await _baseRepositorio.Update(funcionario)
                });
            }
            catch (Exception)
            {
                if (!(_baseRepositorio.Exists(id)))
                {
                    return NotFound("Funcionario não encontrado !");
                }

                return StatusCode(500, "Erro !");
            }
        }
    }
}
