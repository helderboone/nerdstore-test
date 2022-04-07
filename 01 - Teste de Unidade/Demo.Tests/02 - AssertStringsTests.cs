using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringTools_UnirNomes_RetornarNomeCompleto()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.Equal("Helder Borges", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.Equal("HELDER BORGES", nomeCompleto, true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.Contains("orges", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.StartsWith("Held", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveAcabarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.EndsWith("rges", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Helder", "Borges");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}
