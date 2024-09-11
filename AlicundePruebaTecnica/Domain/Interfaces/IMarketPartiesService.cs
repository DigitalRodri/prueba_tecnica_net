using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IMarketPartiesService
    {
        public IEnumerable<RetailerDto> GetAllRetailers();
        RetailerDto GetRetailer(int reId);
    }
}
