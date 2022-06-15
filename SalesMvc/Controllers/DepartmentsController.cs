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
    }
}
