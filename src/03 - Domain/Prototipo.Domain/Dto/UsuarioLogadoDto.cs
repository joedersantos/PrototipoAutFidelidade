using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo.Domain.Dto
{
    public class UsuarioLogadoDto
    {
        public string Nome { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
