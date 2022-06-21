using System.ComponentModel.DataAnnotations;

namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = "{0} size should be between {2} {1} ")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Range(500,20000)]
        [Display(Name="Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }


        public Department? Department { get; set; }
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
