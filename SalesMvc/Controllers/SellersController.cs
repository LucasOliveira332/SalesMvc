using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Data;

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
    }
}
