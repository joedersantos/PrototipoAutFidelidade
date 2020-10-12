using MediatR;

namespace Prototipo.Domain.Commands
{
    public class CriarUsuarioCommand : IRequest<Models.Usuario>
    {
        public CriarUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
    }
}
