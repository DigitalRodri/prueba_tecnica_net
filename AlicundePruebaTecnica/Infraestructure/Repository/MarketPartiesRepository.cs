using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repository.Models;

namespace Infraestructure.Repository
{
    public class MarketPartiesRepository : IMarketPartiesRepository
    {
        private readonly MarketPartiesContext _marketPartiesContext;

        public MarketPartiesRepository(MarketPartiesContext marketPartiesContext)
        {
            _marketPartiesContext = marketPartiesContext;
        }

        public IEnumerable<Retailer> GetAllRetailers()
        {
            return _marketPartiesContext.Retailers;
        }

        public Retailer GetRetailer(int reId)
        {
            return _marketPartiesContext.Retailers.Find(reId);
        }

        public IEnumerable<Retailer> FillDB(IEnumerable<Retailer> retailersList)
        {
            _marketPartiesContext.Retailers.AddRange(retailersList);
            _marketPartiesContext.SaveChanges();
            return retailersList;
        }
    }
}
