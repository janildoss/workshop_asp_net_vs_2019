using SalesWebMvc_n.Data;
using SalesWebMvc_n.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        //decorar com o Async e await
        public async Task<List<Department>> FindAllAsync() {
            return await _Context.Department.OrderBy(x => x.Name).ToListAsync();        
        }
    }
}
