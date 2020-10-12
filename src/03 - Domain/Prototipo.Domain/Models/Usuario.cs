using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo.Domain.Models
{
    public class Usuario
    {
        //private Usuario()
        //{
        //    EnderecosEntrega = new HashSet<Endereco>();
        //}

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Endereco> EnderecosEntrega { get; set; }
    }
}
