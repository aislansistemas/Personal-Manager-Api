using System;

namespace PersonalManagement.Api.Exceptions
{
    public class InvalidModelStateException : ApplicationException
    {
        public InvalidModelStateException(string mensagem) : base (mensagem) {}
    }
}