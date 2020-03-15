using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Data;
namespace SalesWebMvc_n.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc_nContext _Context;

        public SellerService(SalesWebMvc_nContext context) {
            _Context = context;
        }

        public List<Seller> FindAll(){
            return _Context.Seller.ToList(); 
        }


    }
}
