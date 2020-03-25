using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc_n.Services.Exceptions;

namespace SalesWebMvc_n.Services
{
    public class SellerService
    {  //cria uma instancia de Data: _context variavel do tipo SalesWebMvc_nContext
        private readonly SalesWebMvc_nContext _context;
        //Construtor recebe a classe de contexto que representa as 
        //entidades(Seller,Departments,SalesRecord...)
        public SellerService(SalesWebMvc_nContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            //obj.Department = _Context.Department.First(); usado para pegar o primeiro departamento.
            _context.Add(obj);
            _context.SaveChanges();
        }
        //Busca no banco o vendedor pelo id passado
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        //Remove o vendedor da lista e salva no banco a delecao 
        public void Remove(int id)
        {
            //busca o vendedor pelo id passado
            var obj = _context.Seller.Find(id);
            //remove o objeto do DdSet 
            _context.Seller.Remove(obj);
            //Efetiva a remocao no banco de dados
            _context.SaveChanges();
        }

        public void Update(Seller obj) {

            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id Not found");
            }
            //se passar e porque existe
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e){
                throw new DbConcurrencyException(e.Message);                
            }
        }
    }
}
