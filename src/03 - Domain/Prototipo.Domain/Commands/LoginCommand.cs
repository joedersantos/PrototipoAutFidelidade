using MediatR;

namespace Prototipo.Domain.Commands
{
    public class LoginCommand : IRequest<Dto.UsuarioLogadoDto>
    {
        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; }
        public string Senha { get; }
    }
}
