using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SalesMvcContext _context;

        public SellersController(SalesMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            SallerServices saller = new SallerServices();

            return View(saller.FindAll(_context));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Seller seller)
        {
            SallerServices sallerServices = new SallerServices();
            sallerServices.AddSaller(_context, seller);
            return RedirectToAction("Index");
        }

    }

    
    
}
