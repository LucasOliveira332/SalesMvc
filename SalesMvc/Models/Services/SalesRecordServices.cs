using SalesMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesMvc.Models.Services
{
    public class SalesRecordServices
    {
        private readonly SalesMvcContext _context;

        public SalesRecordServices(SalesMvcContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindAll()
        {
            return _context.SalesRecords.Include(x => x.Seller).OrderBy(x => x.Seller.Name).ToList();
        }

        public SalesRecord FindSale(int? id)
        {
            return _context.SalesRecords.Find(id);
        }

        public List<SalesRecord> FindByDate(DateTime minDate, DateTime maxDate)
        {
            return _context.SalesRecords.Where(x => x.Date >= minDate && x.Date <= maxDate).Include(x => x.Seller).ToList();
        }
    }
}

