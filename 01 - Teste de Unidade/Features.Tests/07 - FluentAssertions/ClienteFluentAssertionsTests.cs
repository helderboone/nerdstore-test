using FluentAssertions;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteFluentAssertionsTests
    {
        private readonly ClienteTestsAutoMockerFixture _clienteTestsAutoMockFixture;

        public ClienteFluentAssertionsTests(ClienteTestsAutoMockerFixture clienteTestsAutoMockFixture)
        {
            _clienteTestsAutoMockFixture = clienteTestsAutoMockFixture;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Fluent Assertion Testes")]
        public void Cliente_NovoCliente_DeveEstaValido()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            //Assert
            result.Should().BeTrue();
            cliente.ValidationResult.Errors.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Fluent Assertion Testes")]
        public void Cliente_NovoCliente_DeveEstaInvalido()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            //Assert
            result.Should().BeFalse();
            cliente.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1);
        }
    }
}
