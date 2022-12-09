using SistemaWebEcommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaWebEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaWebEcommerce.Services
{
    public class RegistroVendasService
    {
        private readonly SistemaWebEmcommerceContext _context;

        public RegistroVendasService(SistemaWebEmcommerceContext context)
        {
            _context = context;
        }

        public List<RegistroVenda> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.RegistroVenda select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);
            }
            return resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToList();
        }

        public List<IGrouping<Departamento,RegistroVenda>> FindByDateGroup(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.RegistroVenda select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);
            }
            return resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToList();
        }
    }
}
