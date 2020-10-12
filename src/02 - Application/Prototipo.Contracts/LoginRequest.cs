using System;
using System.ComponentModel.DataAnnotations;

namespace Prototipo.Contracts
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
