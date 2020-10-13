using Prototipo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.App
{
    public interface IUsuarioAppService
    {
        Task<UsuarioResponse> Incluir(CriarUsuarioRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        ValueTask AtaulizarEndereco(SalvarEnderecoEntregaRequest request);
    }
}
