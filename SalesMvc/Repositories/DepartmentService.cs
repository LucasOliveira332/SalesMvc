using SalesMvc.Contracts;
using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Models.Services
{

    public class DepartmentService : IDepartmentService
    {

        private readonly SalesMvcContext _context;
        public DepartmentService(SalesMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Departments.OrderBy(x => x.Name).ToList();
        }

        public Department FindById(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Remove(Department department)
        {

            var removeSeller = _context.Sellers.Where(x => x.DepartmentID == department.Id).ToList();

            if(removeSeller != null)
            {
                foreach (var item in removeSeller)
                {
                    var salesRecords = _context.SalesRecords.Where(x => x.SellerID == item.Id);
                    if(salesRecords != null)
                    {
                        _context.SalesRecords.RemoveRange(salesRecords);
                        _context.SaveChanges();
                    }
                    
                }
                _context.Sellers.RemoveRange(removeSeller);
                _context.SaveChanges();
            }
            var removeDepartment = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
            _context.Departments.Remove(removeDepartment);
            _context.SaveChanges();
        }
    }
}
