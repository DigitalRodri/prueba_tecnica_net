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
    }
}
