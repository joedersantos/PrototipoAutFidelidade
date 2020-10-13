using System;
using System.ComponentModel.DataAnnotations;

namespace Prototipo.Contracts
{
    public class SalvarEnderecoEntregaRequest
    {
        [Required]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }
    }
}
