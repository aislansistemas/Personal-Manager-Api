using System;

namespace PersonalManagement.Api.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mensagem) : base (mensagem){

        }
    }
}