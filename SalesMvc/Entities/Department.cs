namespace SalesMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Seller> Sallers { get; set; } = new List<Seller>();

        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }
    }
}
