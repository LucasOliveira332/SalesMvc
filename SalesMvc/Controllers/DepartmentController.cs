using Microsoft.AspNetCore.Mvc;
using SalesMvc.Contracts;
using SalesMvc.Models;
using SalesMvc.Models.Services;
using SalesMvc.Models.ViewModels;
using System.Diagnostics;

namespace SalesMvc
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var listDepartment = _departmentService.FindAll();
            if (!listDepartment.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "There are no registred Departments" });
            }
            return View(listDepartment);
        }

        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }
    }
}
