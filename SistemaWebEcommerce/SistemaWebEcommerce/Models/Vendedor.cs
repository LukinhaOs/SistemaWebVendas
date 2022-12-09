using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SistemaWebEcommerce.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} Nome muito pequeno, é requerido no minímo de {2} a {1} lêtras")]
        
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} requerido")]


        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} requerido")]


        [Display(Name = "Nascimento")] // Annotation, permite realizar uma edição no nome da variável
        [DataType(DataType.Date)] // Use 'Display' para inserir um Annotation!
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        

        [Display (Name = "Salário")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        [Range(100.0, 1000000.0, ErrorMessage = "{0} deve ser informado com números {1} até R${2}")]
        public double SalarioBase { get; set; }
        [Required(ErrorMessage = "{0} requerido")]


        public Departamento Departamento { get; set; }
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataNasc, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVenda rv)
        {
            Vendas.Add(rv);
        }

        public void RemoveVendas(RegistroVenda rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(rv => rv.Data >= inicio && rv.Data <= fim).Sum(rv => rv.Quantia);
        }
    }
} 
