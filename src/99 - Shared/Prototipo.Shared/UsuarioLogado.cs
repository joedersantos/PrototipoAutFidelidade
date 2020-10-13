using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo.Shared
{
    public class UsuarioLogado
    {
        private readonly IHttpContextAccessor _accessor;

        public UsuarioLogado(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid Id => RecuperarId();

        private Guid RecuperarId()
        {
            var id = _accessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            Guid.TryParse(id,out Guid result);
            return result;
        }

    }
}
