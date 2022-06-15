using SalesMvc.Models.ViewModels;
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
        private readonly DepartmentServices _departmentServices;

        public SellersController(SeedingService seedingService, SallerServices sellerService, DepartmentServices departmentServices)
        {
            _seedingService = seedingService;
            _sallerService = sellerService;
            _departmentServices = departmentServices;
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
            var departments = _departmentServices.FindAll();

            var viewModel = new SellerViewModel{ Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sallerService.AddSaller(seller);
            return RedirectToAction(nameof(Index));
        }

    }
}
