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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            //obj.Department = _Context.Department.First(); usado para pegar o primeiro departamento.
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        //Busca no banco o vendedor pelo id passado
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //Remove o vendedor da lista e salva no banco a delecao 
        public async Task RemoveAsync(int id)
        {
            try
            {
                //busca o vendedor pelo id passado
                var obj = await _context.Seller.FindAsync(id);
                //remove o objeto do DdSet 
                _context.Seller.Remove(obj);
                //Efetiva a remocao no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) 
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Seller obj) {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if(!hasAny)
            {
                throw new NotFoundException("Id Not found");
            }
            //se passar e porque existe
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e){
                throw new DbConcurrencyException(e.Message);                
            }
        }
    }
}
