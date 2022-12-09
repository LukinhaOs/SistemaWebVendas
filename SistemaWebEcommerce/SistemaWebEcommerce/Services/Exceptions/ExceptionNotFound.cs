using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEcommerce.Services.Exceptions
{
    public class ExceptionNotFound : ApplicationException
    {
        public ExceptionNotFound(string message) : base(message)
        {

        }
    }
}
