using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            // Arrange && Act
            var funcionario = new Funcionario(string.Empty, 1000);

            //Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        public void Funcionario_Nome_NaoDeveTerApelido()
        {
            // Arrange && Act
            var funcionario = new Funcionario("Helder", 1000);

            //Assert
            Assert.Null(funcionario.Apelido);

            //Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }
    }
}
