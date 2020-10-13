using System;

namespace Prototipo.Shared.CustomException
{
    public class UsuarioNaoFoiEncontradoException : Exception
    {
        public UsuarioNaoFoiEncontradoException() : base("Usuario não foi encontrado.") { }
        public UsuarioNaoFoiEncontradoException(string message) : base(message) { }
        public UsuarioNaoFoiEncontradoException(string message, Exception inner) : base(message, inner) { }
    }
}
