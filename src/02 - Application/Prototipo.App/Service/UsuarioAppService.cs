using Prototipo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.App.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        public async Task Incluir(CriarUsuarioRequest request)
        {
            await Task.CompletedTask;
        }
    }
}
