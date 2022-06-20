using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models;
using SalesMvc.Contracts;

namespace SalesMvc.Controllers
{

    public class SellerController : Controller
    {

        private readonly ISellerService _sellerServices;
        private readonly DepartmentServices _departmentServices;

        public SellerController(ISellerService sellerServices, DepartmentServices departmentServices)
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
            if(seller == null)
            {
                return NotFound();
            }
            _sellerServices.Add(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var listDepartments = _departmentServices.FindAll();
            var seller = _sellerServices.Find(id);
            var listDepartmentsAndSeller = new SellerViewModel() { Seller = seller, Departments = listDepartments } ;
            return View(listDepartmentsAndSeller);

        }

        [HttpPost]
        public IActionResult Edit(Seller seller)
        {
            _sellerServices.Edit(seller);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var seller = _sellerServices.Find(id);
            return View(seller);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var seller = _sellerServices.Find(id);
            return View(seller);
        }

    }

}
