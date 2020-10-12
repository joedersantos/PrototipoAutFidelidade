using Prototipo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.App
{
    public interface IUsuarioAppService
    {
        Task Incluir(CriarUsuarioRequest request);
    }
}
