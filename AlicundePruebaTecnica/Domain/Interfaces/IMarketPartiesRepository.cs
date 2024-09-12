using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMarketPartiesRepository
    {
        IEnumerable<Retailer> FillRetailers(IEnumerable<Retailer> retailersList);
        public IEnumerable<Retailer> GetAllRetailers();
        Retailer GetRetailer(int reId);
    }
}
