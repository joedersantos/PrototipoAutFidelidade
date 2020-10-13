using MediatR;
using Prototipo.Domain.Commands;
using Prototipo.Domain.Models;
using Prototipo.Domain.Repository;
using Prototipo.Shared;
using Prototipo.Shared.CustomException;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototipo.Domain.Handlers
{
    public class SalvarEnderecoHandler : IRequestHandler<SalvarEnderecoCommand, Models.Usuario>
    {
        private readonly IUsuarioRepository repository;

        public SalvarEnderecoHandler(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Usuario> Handle(SalvarEnderecoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await repository.BuscarPorId(request.IdUsuario);
            if(usuario == null) 
                throw new UsuarioNaoFoiEncontradoException();

            if (usuario.EnderecosEntrega == null)
            {
                var endereco = new Endereco
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuario.Id,
                    Cep = request.Cep,
                    Cidade = request.Cidade,
                    Logradouro = request.Logradouro,
                    Numero = request.Numero,
                    UF = request.UF,
                    DataCriacao = DateTime.UtcNow,
                    DataAtaulizacao = DateTime.UtcNow
                };

                return await repository.Inserir(endereco);
            }
           
                usuario.EnderecosEntrega.Cep = request.Cep;
                usuario.EnderecosEntrega.Cidade = request.Cidade;
                usuario.EnderecosEntrega.Logradouro = request.Logradouro;
                usuario.EnderecosEntrega.Numero = request.Numero;
                usuario.EnderecosEntrega.UF = request.UF;
                usuario.EnderecosEntrega.DataAtaulizacao = DateTime.UtcNow;

            return await repository.AtaulizarEndereco(usuario);
        }
    }
}
