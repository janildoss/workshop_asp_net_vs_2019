using SalesWebMvc_n.Data;
using SalesWebMvc_n.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc_n.Services
{
    public class DepartmetService
    {
        private readonly SalesWebMvc_nContext _Context;
        //Construtor recebe a classe de contexto que representa as 
        //entidades(Seller,Departments,SalesRecord...)
        public DepartmetService(SalesWebMvc_nContext context)
        {
            _Context = context;
        }

        public List<Department> FindAll() {
            return _Context.Department.OrderBy(x => x.Name).ToList();
        
        }
    }
}
