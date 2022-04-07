using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 10000);

            //Assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoVariadoPessoa()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 10000);

            //Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}
