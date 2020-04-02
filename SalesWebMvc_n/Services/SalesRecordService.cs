using System;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc_n.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvc_nContext _Context;
        //Construtor recebe a classe de contexto que representa as 
        //dependencias (SalesRecordService...)
        public  SalesRecordService(SalesWebMvc_nContext context)
        {
           _Context = context;
        }

        public async Task<List<SalesRecord>> FindByDate(DateTime? minDate, DateTime? maxDate) {
            var result = from obj in _Context.SalesRecord select obj;
            if (minDate.HasValue) {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }


    }
}
