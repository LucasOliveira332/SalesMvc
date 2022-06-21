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
            var result = _context.Departments!.OrderBy(x => x.Name).ToList();
            if (result.Any())
            {
                return result;
            }
            else
            {
                return null!;
            }
        }

    }
}
