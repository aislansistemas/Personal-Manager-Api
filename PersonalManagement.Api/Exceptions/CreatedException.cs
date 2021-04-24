using System;

namespace PersonalManagement.Api.Exceptions
{
    public class CreatedException : ApplicationException
    {
        public CreatedException(string mensagem) : base (mensagem){}
    }
}