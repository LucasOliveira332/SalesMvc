using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models;
using SalesMvc.Contracts;
using System.Diagnostics;

namespace SalesMvc.Controllers
{

    public class SellerController : Controller
    {

        private readonly ISellerService _sellerServices;
        private readonly IDepartmentService _departmentServices;

        public SellerController(ISellerService sellerServices, IDepartmentService departmentServices)
        {
            _sellerServices = sellerServices;
            _departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
            var listSellers = _sellerServices.FindAll();
            if (!listSellers.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "There are no registred sellers" });
            }
            return View(listSellers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listDepartments = _departmentServices.FindAll();
            if (!listDepartments.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "Departments not found" });
            }

            var listDepartmentsAndSeller = new SellerViewModel { Departments = listDepartments };
            return View(listDepartmentsAndSeller);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var listDepartments = _departmentServices.FindAll();

                var listDepartmentsAndSeller = new SellerViewModel { Seller = seller, Departments = listDepartments };
                return View(listDepartmentsAndSeller);
            }
            _sellerServices.Add(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provider" });
            }
            var listDepartments = _departmentServices.FindAll();
            if (!listDepartments.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "Departments not found" });
            }
            var seller = _sellerServices.Find((int)id);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }
            var listDepartmentsAndSeller = new SellerViewModel() { Seller = seller, Departments = listDepartments };
            return View(listDepartmentsAndSeller);

        }

        [HttpPost]
        public IActionResult Edit(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }
            _sellerServices.Edit(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provider"});
            }
            var seller = _sellerServices.Find((int)id);
            if(seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }
            return View(seller);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var seller = _sellerServices.Find((int)id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }
            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provider" });
            }
            var seller = _sellerServices.Find((int)id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }
            return View(seller);
        }

        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }

    }

}
