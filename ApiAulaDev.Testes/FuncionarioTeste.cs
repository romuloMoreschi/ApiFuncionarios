using Moq;
using Xunit;
using System;
using ApiAulaDev.Data;
using ApiAulaDev.Models;
using ApiAulaDev.Repositorio;
using Microsoft.EntityFrameworkCore;
using ApiAulaDev.Repositorio.Interfaces;

namespace ApiAulaDev.Testes
{
    public class FuncionarioTeste
    {
        private readonly Context _context;
        public FuncionarioTeste()
        {
            var _dbContextOptions = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new Context(_dbContextOptions);
        }
        [Fact]
        public void TestCreate()
        {
            //Arrange
            Funcionario funcionario = new("José", "Carlos","945.427.800-23" ,"A1567SSQNU", "Tecnologia");

            Mock<IBaseRepositorio<Funcionario>> mock = new ();
            mock.Setup(m => m.Create(funcionario)).ReturnsAsync(funcionario);

            //Act
            var resultadoEsperado = mock.Object.Create(funcionario).Result;
            var verifica = new BaseRepositorio<Funcionario>(_context).Create(funcionario).Result;

            //Assert
            Assert.Equal(verifica, resultadoEsperado);
        }
    }
}
