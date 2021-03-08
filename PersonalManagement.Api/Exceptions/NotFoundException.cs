using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base(mensagem) { }
    }
}
