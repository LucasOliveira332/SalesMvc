namespace SalesMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sallers { get; set; } = new List<Seller>();

        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }

        public void AddSaller(Seller saller)
        {
            Sallers.Add(saller);
        }
        public double TotalSales(DateTime initial, DateTime end)
        {
           return Sallers.Sum(x => x.TotalSales(initial, end));
        }
    }
}
