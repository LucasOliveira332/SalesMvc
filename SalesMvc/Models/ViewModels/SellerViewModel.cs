namespace SalesMvc.Models.ViewModels
{
    public class SellerViewModel
    {
        public Seller? Seller { get; set; }
        public List<Department>? Departments { get; set; }
        public Department? Department { get; set; }

        public SellerViewModel()
        {
        }
    }
}
