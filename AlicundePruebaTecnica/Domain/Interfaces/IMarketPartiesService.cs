using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IMarketPartiesService
    {
        public IEnumerable<RetailerDto> GetAllAccounts();
    }
}
