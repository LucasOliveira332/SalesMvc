using SalesMvc.Models;

namespace SalesMvc.Contracts
{
    public interface ISalesRecordService
    {
        List<SalesRecord> FindAll();

        List<SalesRecord> FindByDate(DateTime minDate, DateTime maxDate);
    }
}
