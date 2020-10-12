using System;
using System.ComponentModel.DataAnnotations;

namespace Prototipo.Contracts
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
