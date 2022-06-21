using SalesMvc.Models;

namespace SalesMvc.Contracts
{
    public interface ISellerService
    {
        List<Seller> FindAll();
        Seller Find(int id);
        void Add(Seller seller);
        void Edit(Seller seller);
        void Remove(int id);
    }
}
