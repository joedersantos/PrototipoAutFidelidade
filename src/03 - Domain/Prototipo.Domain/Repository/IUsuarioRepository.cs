using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<Models.Usuario> Inserir(Models.Usuario model);
        Task<bool> EmailCadastrado(string email);
        Task<Models.Usuario> BuscarPorEmailSenha(string email, string senha);
        Task<Models.Usuario> BuscarPorId(Guid id);
        Task<Models.Usuario> AtaulizarEndereco(Models.Usuario model);
        Task<Models.Usuario> Inserir(Models.Endereco model);
        

    }
}
