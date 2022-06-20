using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;

namespace SalesMvc.Controllers
{

    public class SalesRecordController : Controller
    {

        private readonly SalesRecordService _salesRecordServices;

        public SalesRecordController(SalesRecordService  salesRecordServices)
        {
            _salesRecordServices = salesRecordServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listSalesRecords = _salesRecordServices.FindAll();
            return View(listSalesRecords);
        }

        [HttpPost]
        public IActionResult Index(DateTime minDate, DateTime maxDate)
        {
           var FindSalesPerDate = _salesRecordServices.FindByDate(minDate,maxDate);

            return View(FindSalesPerDate);
        }

    }

}
