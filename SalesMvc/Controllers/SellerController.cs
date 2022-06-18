using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models;

namespace SalesMvc.Controllers
{

    public class SellerController : Controller
    {

        private readonly SellerServices _sellerServices;
        private readonly DepartmentServices _departmentServices;

        public SellerController(SellerServices sellerServices, DepartmentServices departmentServices)
        {
            _sellerServices = sellerServices;
            _departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
            var listSellers = _sellerServices.FindAll();
            return View(listSellers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listDepartments = _departmentServices.FindAll();

            var listDepartmentsAndSeller = new SellerViewModel { Departments = listDepartments };
            return View(listDepartmentsAndSeller);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.AddSaller(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var seller = _sellerServices.FindSeller(id);
            return View(seller);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _sellerServices.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var seller = _sellerServices.FindSeller(id);
            return View(seller);
        }

    }

}
