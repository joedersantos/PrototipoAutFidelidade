using System;

namespace Prototipo.Contracts
{
    public class LoginResponse
    {
        public string Nome { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
