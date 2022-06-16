using SalesMvc.Data;

namespace SalesMvc.Models.Services
{
    public class DepartmentServices
    {
        private readonly SalesMvcContext _context;
        public DepartmentServices(SalesMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Departments!.OrderBy(x => x.Name).ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public Seller FindDepartment(int? id)
        {
            Seller? x = _context.Sellers?.FirstOrDefault(x => x.Id == id);
            return x!;
        }

        public void RemoveDepartment(int id)
        {
            var removeDepartment = _context.Departments?.FirstOrDefault(x => x.Id == id);

            var removeSeller = _context.Sellers?.Where(x => x.DepartmentID == id);

            var removeSalesRecord = _context.SalesRecords?.Where(x => x.SellerID.Equals(removeSeller));

            _context.SalesRecords.RemoveRange(removeSalesRecord);
            _context.SaveChanges();

            _context.Sellers.RemoveRange(removeSeller);
            _context.SaveChanges();

            _context.Remove(removeDepartment);
            _context.SaveChanges();
        }
    }
}
