using SalesMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesMvc.Models.Services
{
    public class SalesRecordServices { 
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

        public List<SalesRecord> FindSalesPerDate(DateTime inital, DateTime end)
        {
            return _context.SalesRecords.Where(x => x.Date >= inital && x.Date <= end).Include(x=> x.Seller).ToList();
        }

        public void AddSale(SalesRecord salesRecord)
        {
            _context.SalesRecords.Add(salesRecord);
            _context.SaveChanges();
        }

        public void RemoveSale(int id)
        {
            var sale = _context.SalesRecords.Find(id);
            _context.SalesRecords.Remove(sale);
            _context.SaveChanges();
        }
    }
}

