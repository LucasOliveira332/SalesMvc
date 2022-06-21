using SalesMvc.Models;

namespace SalesMvc.Contracts
{
    public interface IDepartmentService
    {
        List<Department> FindAll();
    }
}
