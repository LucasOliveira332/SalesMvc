using SalesMvc.Models;

namespace SalesMvc.Contracts
{
    public interface IDepartmentService
    {
        List<Department> FindAll();
        Department FindById(int id);
        void Add(Department department);
        void Remove(Department department);
    }
}
