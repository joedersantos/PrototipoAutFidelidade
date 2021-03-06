﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Prototipo.Contracts
{
    public class CriarUsuarioRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
