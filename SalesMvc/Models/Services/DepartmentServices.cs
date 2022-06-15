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
    }
}
