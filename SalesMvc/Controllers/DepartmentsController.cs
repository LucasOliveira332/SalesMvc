using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models;
using SalesMvc.Models.Services;

namespace SalesMvc
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentServices _departmentService;

        public DepartmentsController(DepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
           var list =  _departmentService.FindAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _departmentService.AddDepartment(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            //var findSeller = _sallerService.FindSeller(id);
            return View();

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            //_sallerService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
