using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models;
using SalesMvc.Models.Services;

namespace SalesMvc
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
           var listDepartments =  _departmentService.FindAll();
            return View(listDepartments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _departmentService.Add(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var department = _departmentService.FindById((int)id);
            if(department != null)
            {
                var findDepartment = _departmentService.FindById((int)id);
                return View(findDepartment);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var department = _departmentService.FindById(id);
            if (department != null)
            {
                _departmentService.Remove(department);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
