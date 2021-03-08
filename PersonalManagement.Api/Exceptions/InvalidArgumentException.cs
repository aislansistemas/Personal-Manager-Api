using System;

namespace PersonalManagement.Api.Exceptions
{
    public class InvalidArgumentException : ApplicationException
    {
        public InvalidArgumentException(string mensagem) : base (mensagem) {} 
    }
}