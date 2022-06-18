namespace SalesMvc.Models.ViewModels
{
    public class SalesViewModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public SalesRecord Sale { get; set; }
        public List<SalesRecord> Sales { get; set; }
        public List<Seller> Sellers { get; set; }

        public SalesViewModel()
        {
        }
    }
}

