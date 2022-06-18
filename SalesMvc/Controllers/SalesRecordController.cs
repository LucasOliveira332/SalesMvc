using SalesMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models.Services;
using SalesMvc.Models;

namespace SalesMvc.Controllers
{

    public class SalesRecordController : Controller
    {

        private readonly SalesRecordServices _salesRecordServices;
        private readonly SellerServices _sellerServices;

        public SalesRecordController(SellerServices sellerServices, SalesRecordServices  salesRecordServices)
        {
            _sellerServices = sellerServices;
            _salesRecordServices = salesRecordServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listSalesRecords = _salesRecordServices.FindAll();

            SalesViewModel salesViewModel = new SalesViewModel() { Sales = listSalesRecords };
            return View(salesViewModel);
        }

        [HttpPost]
        public IActionResult Index(SalesViewModel salesViewModel)
        {
           var FindSalesPerDate = _salesRecordServices.FindSalesPerDate(salesViewModel.InitialDate, salesViewModel.FinalDate).ToList();

            salesViewModel = new SalesViewModel() { Sales = FindSalesPerDate };
            return View(salesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listSellers = _sellerServices.FindAll().ToList();
            SalesViewModel salesViewModel = new SalesViewModel() { Sellers = listSellers };
            return View(salesViewModel);
        }

        [HttpPost]
        public IActionResult Create(SalesRecord salesRecord)
        {
            _salesRecordServices.AddSale(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            var salesRemove = _salesRecordServices.FindSale(id);
            return View(salesRemove);

        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _salesRecordServices.RemoveSale(id);
            return RedirectToAction(nameof(Index));
        }

    }

}
