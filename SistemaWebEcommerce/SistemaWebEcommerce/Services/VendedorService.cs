using SistemaWebEcommerce.Data;
using SistemaWebEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaWebEcommerce.Services.Exceptions;

namespace SistemaWebEcommerce.Services
{
    public class VendedorService
    {
        private readonly SistemaWebEmcommerceContext _context;

        public VendedorService(SistemaWebEmcommerceContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Enviar(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id)
        {
            var objVendedor = _context.Vendedor.Find(id);

            if (objVendedor != null)
            {
                try
                {
                    //Método prático
                    var obj = _context.Vendedor.Find(id);
                    _context.Vendedor.Remove(obj);
                    _context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    throw new IntegrityException(e.Message);
                }

                /* //Método didático

                var objVendas = _context.RegistroVenda.Where(x => x.VendedorId == id);
                foreach (var venda in objVendas)
                {
                    _context.RegistroVenda.Remove(venda);
                }
                _context.SaveChanges();
                _context.Vendedor.Remove(objVendedor); */
            }
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new ExceptionNotFound("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ExceptionSimultanea(e.Message);
            }
        }
    }
}