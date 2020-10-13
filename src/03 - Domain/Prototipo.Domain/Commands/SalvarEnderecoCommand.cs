using MediatR;
using System;

namespace Prototipo.Domain.Commands
{
    public class SalvarEnderecoCommand : IRequest<Models.Usuario>
    {
        public SalvarEnderecoCommand(Guid idUsuario, string logradouro, int numero, string cep, string cidade, string uf)
        {
            IdUsuario = idUsuario;
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Cidade = cidade;
            UF = uf;
        }

        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public Guid IdUsuario { get; set; }
    }
}
