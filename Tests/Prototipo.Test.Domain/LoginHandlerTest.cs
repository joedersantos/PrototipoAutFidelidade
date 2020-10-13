using Moq;
using Prototipo.Domain.Repository;
using System;
using Xunit;
using FluentAssertions;
using Prototipo.Domain.Models;
using System.Threading.Tasks;
using Prototipo.Domain.Handlers;
using Prototipo.Domain.Commands;
using System.Threading;
using Prototipo.Domain.Dto;
using Prototipo.Shared.CustomException;

namespace Prototipo.Test.Domain
{
    public class LoginHandlerTest
    {
        private readonly Mock<IUsuarioRepository> _repository = new Mock<IUsuarioRepository>();
               
        [Fact]
        public async Task Handler_UsuarioLogadoDto()
        {
            const string nome = "Nome moq";
            const string email = "moq@moq.com";

            _repository.Setup(x => x.BuscarPorEmailSenha(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => Task.FromResult( new Usuario()
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Nome = nome
                }));

            var handler = new LoginHandler(_repository.Object);
            var command = new LoginCommand(email, "*****");
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            act.Should().NotThrow();
            _repository.Verify(x => x.BuscarPorEmailSenha(It.IsAny<string>(), It.IsAny<string>()));

            command.Email.Should().Be(email);
            command.Senha.Should().Be("*****");

            var result = await handler.Handle(command, CancellationToken.None);
            result.Should().BeOfType<UsuarioLogadoDto>();
            result.Nome.Should().Be(nome);
            result.Token.Should().NotBeNullOrWhiteSpace();            
        }
        [Fact]
        public async Task Handler_UsuarioNaoFoiEncontradoException()
        {
            const string email = "moq@moq.com";
            Usuario usuario = null;
            _repository.Setup(x => x.BuscarPorEmailSenha(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => Task.FromResult(usuario));

            var handler = new LoginHandler(_repository.Object);
            var command = new LoginCommand(email, "*****");
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            command.Email.Should().Be(email);
            command.Senha.Should().Be("*****");
                        
            act.Should().Throw<UsuarioNaoFoiEncontradoException>().WithMessage($"Usuario ou senha incorretos!");
        }
    }
}
