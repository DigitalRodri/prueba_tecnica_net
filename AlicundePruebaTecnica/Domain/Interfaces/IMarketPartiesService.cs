using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IMarketPartiesService
    {
        Task<IEnumerable<RetailerDto>> FillDBAsync();
        public IEnumerable<RetailerDto> GetAllRetailers();
        RetailerDto GetRetailer(int reId);
    }
}
