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
        private readonly SeedingService _seedingService;
        private readonly SallerServices _sallerService;

        public SellersController(SeedingService seedingService, SallerServices sallerService)
        {
            _seedingService = seedingService;
            _sallerService = sallerService;

            _seedingService.Seed();
        }

        public IActionResult Index()
        {
            var list = _sallerService.FindAll();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sallerService.AddSaller(seller);
            return RedirectToAction(nameof(Index));
        }

    }
}
