using SalesMvc.Data;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Contracts;

namespace SalesMvc.Models.Services
{
    public class SalesRecordService : ISalesRecordService
    {
        private readonly SalesMvcContext _context;

        public SalesRecordService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindAll()
        {
            List<SalesRecord>? result = _context.SalesRecords!.Include(x => x.Seller).OrderBy(x => x.Seller.Name).ToList();
            if (result.Any())
            {
                return result;
            }
            else
            {
                return null!;
            }
        }
        public List<SalesRecord> FindByDate(DateTime minDate, DateTime maxDate)
        {
            return _context.SalesRecords!.Where(x => x.Date >= minDate && x.Date <= maxDate).Include(x => x.Seller).ToList();
        }
    }
}

