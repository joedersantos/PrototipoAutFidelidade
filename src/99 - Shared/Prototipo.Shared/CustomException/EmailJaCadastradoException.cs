using System;

namespace Prototipo.Shared.CustomException
{
    public class EmailJaCadastradoException : Exception
    {
        public EmailJaCadastradoException() : base("Email Já Cadastrado.") { }
        public EmailJaCadastradoException(string message) : base(message) { }
        public EmailJaCadastradoException(string message, Exception inner) : base(message, inner) { }
    }
}
