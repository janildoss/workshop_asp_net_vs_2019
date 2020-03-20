using SalesWebMvc_n.Data;
using SalesWebMvc_n.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc_n.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc_nContext _Context;
        //Construtor recebe a classe de contexto que representa as 
        //entidades(Seller,Departments,SalesRecord...)
        public DepartmentService(SalesWebMvc_nContext context)
        {
            _Context = context;
        }

        public List<Department> FindAll() {
            //retorna lista de departamentos ordenados pelo nome
            return _Context.Department.OrderBy(x => x.Name).ToList();        
        }
    }
}
