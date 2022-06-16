using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models;
using SalesMvc.Models.Services;

namespace SalesMvc
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentServices _departmentServices;

        public DepartmentsController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
           var list =  _departmentServices.FindAll();
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
            _departmentServices.AddDepartment(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var findDepartment = _departmentServices.FindDepartment(id);
            return View(findDepartment);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _departmentServices.RemoveDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
