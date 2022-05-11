using Features.Clientes;
using FluentAssertions;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceFluentAssertionsTests
    {
        private readonly ClienteTestsAutoMockerFixture _clienteTestsAutoMockFixture;
        private readonly ClienteService _clienteService;

        public ClienteServiceFluentAssertionsTests(ClienteTestsAutoMockerFixture clienteTestsAutoMockFixture)
        {
            _clienteTestsAutoMockFixture = clienteTestsAutoMockFixture;
            _clienteService = clienteTestsAutoMockFixture.ObterClienteService();
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Testes")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockFixture.GerarClienteValido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert
            cliente.EhValido().Should().BeTrue();
            _clienteTestsAutoMockFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
            _clienteTestsAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Testes")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsAutoMockFixture.GerarClienteInvalido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert
            cliente.EhValido().Should().BeFalse();
            cliente.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1);
            _clienteTestsAutoMockFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Never);
            _clienteTestsAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Cliente Ativos")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Testes")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            _clienteTestsAutoMockFixture.Mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos())
                .Returns(_clienteTestsAutoMockFixture.GerarClientesVariados());

            // Act
            var clientes = _clienteService.ObterTodosAtivos();

            // Assert
            clientes.Should().HaveCountGreaterOrEqualTo(1).And.OnlyHaveUniqueItems();
            clientes.Should().OnlyContain(c => c.Ativo);
            clientes.Should().NotContain(c => !c.Ativo);

            _clienteTestsAutoMockFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
        }
    }
}
