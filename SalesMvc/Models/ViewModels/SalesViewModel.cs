using SalesMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesMvc.Models.ViewModels
{
    public class SalesViewModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public SalesRecord Sale { get; set; }
        public List<SalesRecord> Sales { get; set; }
        public List<SaleStatus> SaleStatus { get; set; }
        public SalesViewModel()
        {
        }
    }
}

