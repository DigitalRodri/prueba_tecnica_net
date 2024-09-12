using Domain.DTOs;

namespace Domain.Interfaces
{
    public interface IMarketPartiesService
    {
        Task<IEnumerable<RetailerDto>> FillRetailersAsync();
        public IEnumerable<RetailerDto> GetAllRetailers();
        RetailerDto GetRetailer(int reId);
    }
}
