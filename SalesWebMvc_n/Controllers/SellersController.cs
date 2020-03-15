using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc_n.Services;

namespace SalesWebMvc_n.Controllers
{
    public class SellersController : Controller
    {
        //injecao de dependecia
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService) {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}