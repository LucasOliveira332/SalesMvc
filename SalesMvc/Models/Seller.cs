namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime BirthData { get; set; }
        public double BaseSalary { get; set; }
        public Department? Departments { get; set; }
        public int DepartmentID { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller(){}

        public Seller(string name, string email, DateTime birthData, double baseSalary, Department department)
        {
            
            Name = name;
            Email = email;
            BirthData = birthData;
            BaseSalary = baseSalary;
            Departments = department;

        }

        public void AddSales(SalesRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

        public double TotalSales(DateTime Initial,
                                 DateTime End)
        {
            return SalesRecords.Sum(x => x.Amount);
        }
    }
}
