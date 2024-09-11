using Domain.Entities;
using Domain.Interfaces;

namespace Infraestructure.Repository
{
    public class MarketPartiesRepository : IMarketPartiesRepository
    {
        public IEnumerable<Retailer> GetAllRetailers()
        {
            return new List<Retailer>() { new Retailer(0, "name", "country", "codingScheme", "reCode") };
        }
    }
}
