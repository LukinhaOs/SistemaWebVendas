using SistemaWebEcommerce.Models;
using SistemaWebEcommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEcommerce.Services
{
    public class DepartamentoService
    {
        private readonly SistemaWebEmcommerceContext _context;

        public DepartamentoService(SistemaWebEmcommerceContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
