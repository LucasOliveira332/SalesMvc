using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        public DateTime BirthData { get; set; }
        public double BaseSalary { get; set; }
        public Department Dept { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(string name, string email, DateTime birthData, double baseSalary, Department department)
        {
            
            Name = name;
            Email = email;
            BirthData = birthData;
            BaseSalary = baseSalary;
            Dept = department;

        }

        public void AddSales(SalesRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime end)
        {
            return SalesRecords.Sum(x => x.Amount);
        }
    }
}
