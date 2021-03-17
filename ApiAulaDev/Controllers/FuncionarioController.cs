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
                    Message = "Funcionario cadastrado com sucesso !",
                    Success = true,
                    Data = await _baseRepositorio.Create(funcionario)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
                    Message = "Funcionario atualizado com sucesso !",
                    Success = true,
                    Data = await _baseRepositorio.Update(funcionario)
                });
            }
            catch (Exception e)
            {
                if (!(_baseRepositorio.Exists(id)))
                {
                    return NotFound("Funcionario não encontrado !");
                }

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("/api/v1/funcionarios/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _baseRepositorio.Remove(id);

                return Ok(new
                {
                    Message = "Funcionario removido com sucesso !",
                    Success = true
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/api/v1/funcionarios/get-funcionario/{id}")]
        public async Task<IActionResult> GetFuncionario(int id)
        {
            try
            {
                return Ok(new
                {
                    Success = true,
                    Data = await _baseRepositorio.Get(id)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
