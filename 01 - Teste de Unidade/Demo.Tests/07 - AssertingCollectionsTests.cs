using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 10000);

            //Assert
            Assert.All(funcionario.Habilidades, habilidades => Assert.False(string.IsNullOrWhiteSpace(habilidades)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasicas()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 1000);

            //Assert
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 1000);

            //Assert
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Helder", 15000);

            var habilidadesAvancadas = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            //Assert
            Assert.Equal(habilidadesAvancadas, funcionario.Habilidades);
        }
    }
}
