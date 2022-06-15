using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models;
using SalesMvc.Data;

namespace SalesMvc.Controllers
{
    public class SellersController : Controller
    {
        //private readonly SeedingService _seedingService;
        private readonly SallerServices _sallerService;
        private readonly DepartmentServices _departmentServices;

        public SellersController(SallerServices sellerService, DepartmentServices departmentServices/*SeedingService seedingService*/)
        {
            _sallerService = sellerService;
            _departmentServices = departmentServices;
            //_seedingService = seedingService;
            //_seedingService.Seed();
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

            var viewModel = new SellerViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sallerService.AddSaller(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var sellerTemp = _sallerService.FindSeller(id);
            return View(sellerTemp);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _sallerService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
