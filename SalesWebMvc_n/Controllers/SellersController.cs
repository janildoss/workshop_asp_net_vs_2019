using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc_n.Services;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Models.ViewModels;
using SalesWebMvc_n.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebMvc_n.Controllers
{
    public class SellersController : Controller
    {
        //injecao de dependecia
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        { 

            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {                
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });               
            }
            //se o id nao eh nulo busca pelo id passado
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            //se o id nao eh nulo busca pelo id passado
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
               
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit(int id, Seller seller)
        {  //O framework testa se e valido a execucao com o javascript desabilitado.
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch"});
            }
            try
            {
               await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            //  catch (DbConcurrencyException)//erro interno do banco
            //  {
            //     return NotFound();
            //  }
        } 

        //este metodo nao acessa dados por isso nao precisa ser assynchrono
        public IActionResult Error(string message) {

            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier//opcao do framework p pegar o id interno
            };
            return View(viewModel);
        }

    }
}