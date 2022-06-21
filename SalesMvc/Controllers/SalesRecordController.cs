using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SalesMvc.Contracts;

namespace SalesMvc.Controllers
{

    public class SalesRecordController : Controller
    {

        private readonly ISalesRecordService _salesRecordServices;

        public SalesRecordController(ISalesRecordService salesRecordServices)
        {
            _salesRecordServices = salesRecordServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listSalesRecords = _salesRecordServices.FindAll();
            if (!listSalesRecords.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "There are no registred Sales" });
            }
            return View(listSalesRecords);
        }

        [HttpPost]
        public IActionResult Index(DateTime minDate, DateTime maxDate)
        {
           var FindSalesPerDate = _salesRecordServices.FindByDate(minDate,maxDate);

            return View(FindSalesPerDate);
        }

        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }

    }

}
