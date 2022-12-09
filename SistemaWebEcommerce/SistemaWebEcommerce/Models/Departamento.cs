using System.Collections.Generic;
using System;
using System.Linq;

namespace SistemaWebEcommerce.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {

        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendas(Vendedor dv)
        {
            Vendedores.Add(dv);
        }

        public void RemoveVendas(Vendedor dv)
        {
            Vendedores.Remove(dv);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, fim));
        }
    }
}