using Domain.DTOs;
using Domain.Interfaces;

namespace Domain.Services
{
    public class MarketPartiesService : IMarketPartiesService
    {

        public MarketPartiesService()
        {
        }

        public IEnumerable<RetailerDto> GetAllAccounts()
        {
            return new List<RetailerDto>();
        }
    }
}
