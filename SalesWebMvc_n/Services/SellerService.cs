using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Data;
namespace SalesWebMvc_n.Services
{
    public class SellerService
    {  //cria uma instancia de Data: _context variavel do tipo SalesWebMvc_nContext
        private readonly SalesWebMvc_nContext _Context;
        //Construtor recebe a classe de contexto que representa as 
        //entidades(Seller,Departments,SalesRecord...)
        public SellerService(SalesWebMvc_nContext context) {
            _Context = context;
        }

        public List<Seller> FindAll(){
            return _Context.Seller.ToList(); 
        }

        public void Insert(Seller obj) {
            //obj.Department = _Context.Department.First(); usado para pegar o primeiro departamento.
            _Context.Add(obj);
            _Context.SaveChanges();
        }
    }
}
