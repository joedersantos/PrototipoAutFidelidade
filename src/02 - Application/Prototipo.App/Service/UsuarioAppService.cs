using MediatR;
using Prototipo.Contracts;
using Prototipo.Domain.Commands;
using Prototipo.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.App.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMediator mediator;
        private readonly Guid _usuarioId;

        public UsuarioAppService(IMediator mediator, UsuarioLogado usuario)
        {
            this.mediator = mediator;
            _usuarioId = usuario.Id;
        }

        public async ValueTask AtaulizarEndereco(SalvarEnderecoEntregaRequest request)
        {            
            var cmd = new SalvarEnderecoCommand(_usuarioId, request.Logradouro, request.Numero, request.Cep,request.Cidade, request.UF);

            _ = await mediator.Send(cmd);
        }

        public async Task<UsuarioResponse> Incluir(CriarUsuarioRequest request)
        {
            var cmd = new CriarUsuarioCommand(request.Nome, request.Email, request.Senha);

            var result =  await mediator.Send(cmd);

            return new UsuarioResponse { Id = result.Id, Email = result.Email, Nome = result.Nome };
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var cmd = new LoginCommand(request.Email, request.Senha);

            var dto = await mediator.Send(cmd);

            return new LoginResponse
            {
                Nome = dto.Nome,
                Token = dto.Token,
                TokenType = dto.TokenType,
                DataExpiracao = dto.DataExpiracao               
            };
        }
    }
}
