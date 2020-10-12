using MediatR;
using Microsoft.IdentityModel.Tokens;
using Prototipo.Domain.Commands;
using Prototipo.Domain.Dto;
using Prototipo.Domain.Models;
using Prototipo.Domain.Repository;
using Prototipo.Shared;
using Prototipo.Shared.CustomException;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototipo.Domain.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, UsuarioLogadoDto>
    {
        private readonly IUsuarioRepository repository;

        public LoginHandler(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task<UsuarioLogadoDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await repository.BuscarPorEmailSenha(request.Email, request.Senha.ToMd5());

            if (usuario == null)
                throw new EmailJaCadastradoException("Usuario ou senha incorretos!");

            var handler = new JwtSecurityTokenHandler();
            var chaveSecreta = HeperExtension.ChaveScreta();

            DateTime dataExpiracao = DateTime.UtcNow.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                     new Claim("user_id", usuario.Id.ToString("N"))
               }),
                Expires = dataExpiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveSecreta), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenObj = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(tokenObj);

            var dto = new UsuarioLogadoDto
            {
                Nome = usuario.Nome,
                Token = token,
                TokenType = "bearer",
                DataExpiracao = dataExpiracao
            };
            return dto;
        }
    }
}
