﻿using System;
using ApiAulaDev.Models;
using ApiAulaDev.Repositorio;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiAulaDev.Repositorio.Interfaces;

namespace ApiAulaDev.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IBaseRepositorio<Funcionario> _baseRepositorio;
        public FuncionarioController(BaseRepositorio<Funcionario> baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        [HttpPost]
        [Route("/api/v1/funcionarios/create")]
        public async Task<IActionResult> Create([FromBody] Funcionario funcionario)
        {
            try
            {
                return Ok();
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
                return (IActionResult)await _baseRepositorio.Get();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }
    }
}