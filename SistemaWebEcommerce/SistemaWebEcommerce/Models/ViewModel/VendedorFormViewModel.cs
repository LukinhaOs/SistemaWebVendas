using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEcommerce.Models
{
    public class VendedorFormViewModel
    {
        public Vendedor vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
