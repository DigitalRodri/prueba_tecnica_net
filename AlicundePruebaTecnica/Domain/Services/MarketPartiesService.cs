using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class MarketPartiesService : IMarketPartiesService
    {
        private readonly IMarketPartiesRepository _marketPartiesRepository;
        private readonly IMapper _autoMapper;

        public MarketPartiesService(IMarketPartiesRepository marketPartiesRepository, IMapper mapper)
        {
            _marketPartiesRepository = marketPartiesRepository;
            _autoMapper = mapper;
        }

        public IEnumerable<RetailerDto> GetAllRetailers()
        {
            IEnumerable<Retailer> retailerList = _marketPartiesRepository.GetAllRetailers();

            return _autoMapper.Map<IEnumerable<RetailerDto>>(retailerList);
        }
    }
}
