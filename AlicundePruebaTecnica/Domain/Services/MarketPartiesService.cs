using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System.Net.Http.Json;

namespace Domain.Services
{
    public class MarketPartiesService : IMarketPartiesService
    {
        private readonly IMarketPartiesRepository _marketPartiesRepository;
        private readonly IMapper _autoMapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public MarketPartiesService(IMarketPartiesRepository marketPartiesRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _marketPartiesRepository = marketPartiesRepository;
            _autoMapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<RetailerDto>> FillRetailersAsync()
        {
            IEnumerable<RetailerDto> retailerDtos = await GetRetailersFromWebAsync();

            IEnumerable<Retailer> retailerList = _autoMapper.Map<IEnumerable<Retailer>>(retailerDtos);

            IEnumerable<Retailer> retailerDtosResult = _marketPartiesRepository.FillRetailers(retailerList);


            return _autoMapper.Map<IEnumerable<RetailerDto>>(retailerDtosResult);
        }

        public IEnumerable<RetailerDto> GetAllRetailers()
        {
            IEnumerable<Retailer> retailerList = _marketPartiesRepository.GetAllRetailers();

            return _autoMapper.Map<IEnumerable<RetailerDto>>(retailerList);
        }

        public RetailerDto GetRetailer(int reId)
        {
            Retailer retailer = _marketPartiesRepository.GetRetailer(reId);

            return _autoMapper.Map<RetailerDto>(retailer);
        }

        private async Task<IEnumerable<RetailerDto>> GetRetailersFromWebAsync()
        {
            IList<RetailerDto> retailerDtos = new List<RetailerDto>();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.opendata.esett.com/");
            IAsyncEnumerable<RetailerDto> response = client.GetFromJsonAsAsyncEnumerable<RetailerDto>("EXP01/Retailers");

            await foreach (RetailerDto retailer in response)
            {
                retailerDtos.Add(retailer);
            }

            return retailerDtos;
        }
    }
}
