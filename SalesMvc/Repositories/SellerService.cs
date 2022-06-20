using Microsoft.EntityFrameworkCore;
using SalesMvc.Contracts;
using SalesMvc.Data;

namespace SalesMvc.Models.Services
{
    public class SellerService : ISellerService
    {
        private readonly SalesMvcContext _context;

        public SellerService(SalesMvcContext context)
        {
            _context = context;
        }

        public  List<Seller> FindAll()
        {
            return  _context.Sellers.OrderBy(x => x.Name).ToList();
        }
        public Seller Find(int? id)
        {
            Seller x = _context.Sellers.Include(x=> x.Department).FirstOrDefault(x => x.Id == id);
            return x;
        }
        public void Add(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public void Edit(Seller seller)
        {
            try
            {
                var editSeller = _context.Sellers.Update(seller);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Remove(int id)
        {
            var removeSeller = _context.Sellers.FirstOrDefault(x => x.Id == id);
            var listSalesRecords = _context.SalesRecords.Where(x => x.SellerID == id);

            _context.SalesRecords.RemoveRange(listSalesRecords);
            _context.SaveChanges();

            _context.Remove(removeSeller);
            _context.SaveChanges();
        }
    }
}
