using Moq;
using Xunit;
using ApiAulaDev.Models;
using ApiAulaDev.Repositorio.Interfaces;

namespace ApiAulaDev.Testes
{
    public class FuncionarioTeste
    {
        [Fact]
        public void TestCreate()
        {
            //Arrange
            Funcionario funcionario = new("José", "Carlos","945.427.800-23" ,"A1567SSQNU", "Tecnologia");

            Mock<IBaseRepositorio<Funcionario>> mock = new ();
            mock.Setup(m => m.Create(funcionario)).ReturnsAsync(funcionario);

            //Act
            var resultadoEsperado = mock.Object.Create(funcionario).Result;

            var Teste = resultadoEsperado != null;

            //Assert
            Assert.True(Teste);
        }
    }
}
