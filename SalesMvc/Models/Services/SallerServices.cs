using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMvc.Data;
using SalesMvc.Models;

namespace SalesMvc.Models.Services
{
    public class SallerServices
    {
        private readonly SalesMvcContext _context;

        public SallerServices(SalesMvcContext context)
        {
            _context = context;
        }

        public  List<Seller> FindAll()
        {
            return _context.Sallers.ToList();
        }

        public void AddSaller(Seller seller)
        {
            seller.Dept = _context.Departments.First();
            _context.Add(seller);
            _context.SaveChanges();
        }
    }
}
