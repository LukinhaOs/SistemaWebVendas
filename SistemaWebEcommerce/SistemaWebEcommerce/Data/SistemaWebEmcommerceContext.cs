using Microsoft.EntityFrameworkCore;
using SistemaWebEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEcommerce.Data
{
    public class SistemaWebEmcommerceContext : DbContext
    {
        public SistemaWebEmcommerceContext (DbContextOptions<SistemaWebEmcommerceContext> options)
            :base(options)
        { 
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroVenda> RegistroVenda { get; set; }
    }
}
