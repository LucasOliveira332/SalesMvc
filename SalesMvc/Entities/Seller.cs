using System.ComponentModel.DataAnnotations;

namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }


        public string? Name { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Display(Name="Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }


        public Department Department { get; set; }


        public int DepartmentID { get; set; }


        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(string name, string email, DateTime birthData, double baseSalary, Department department)
        {

            Name = name;
            Email = email;
            BirthDate = birthData;
            BaseSalary = baseSalary;
            Department = department;

        }
    }
}
