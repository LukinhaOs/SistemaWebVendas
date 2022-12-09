using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEcommerce.Services.Exceptions
{
    public class ExceptionSimultanea : ApplicationException
    {
        public ExceptionSimultanea(string message) : base(message)
        {

        }
    }
}
