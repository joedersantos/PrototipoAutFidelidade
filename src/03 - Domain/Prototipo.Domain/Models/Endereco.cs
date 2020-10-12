using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo.Domain.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
