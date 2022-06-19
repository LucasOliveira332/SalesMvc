using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;

namespace SalesMvc.Controllers
{

    public class SalesRecordController : Controller
    {

        private readonly SalesRecordServices _salesRecordServices;

        public SalesRecordController(SalesRecordServices  salesRecordServices)
        {
            _salesRecordServices = salesRecordServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listSalesRecords = _salesRecordServices.FindAll();
            var salesViewModel = new SalesViewModel() { Sales = listSalesRecords };
            return View(salesViewModel);
        }

        [HttpPost]
        public IActionResult Index(SalesViewModel salesViewModel)
        {
           var FindSalesPerDate = _salesRecordServices.FindSalesPerDate(salesViewModel.InitialDate, salesViewModel.FinalDate).ToList();

            salesViewModel = new SalesViewModel() { Sales = FindSalesPerDate };
            return View(salesViewModel);
        }

    }

}
