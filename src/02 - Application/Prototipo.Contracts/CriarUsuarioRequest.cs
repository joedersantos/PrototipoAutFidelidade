using System;

namespace Prototipo.Contracts
{
    public class CriarUsuarioRequest
    {
        public String Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
