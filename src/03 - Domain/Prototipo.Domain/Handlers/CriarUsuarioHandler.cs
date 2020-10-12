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
    public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, Models.Usuario>
    {
        private readonly IUsuarioRepository repository;

        public CriarUsuarioHandler(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Usuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (await repository.EmailCadastrado(request.Email))
                throw new EmailJaCadastradoException();

            var model = new Models.Usuario
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Nome = request.Nome,
                Senha = request.Senha.ToMd5()
            };
            return await repository.Inserir(model);
        }
    }
}
