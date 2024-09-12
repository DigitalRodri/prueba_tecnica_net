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
            IEnumerable<RetailerDto> webRetailersDtoList = await GetRetailersFromWebAsync();
            IEnumerable<Retailer> webRetailersList = _autoMapper.Map<IEnumerable<Retailer>>(webRetailersDtoList);

            IEnumerable<Retailer> retailersDtoResultList = _marketPartiesRepository.FillRetailers(webRetailersList);
            return _autoMapper.Map<IEnumerable<RetailerDto>>(retailersDtoResultList);
        }

        public IEnumerable<RetailerDto> GetAllRetailers()
        {
            IEnumerable<Retailer> retailersList = _marketPartiesRepository.GetAllRetailers();

            return _autoMapper.Map<IEnumerable<RetailerDto>>(retailersList);
        }

        public RetailerDto GetRetailer(int reId)
        {
            Retailer retailer = _marketPartiesRepository.GetRetailer(reId);

            return _autoMapper.Map<RetailerDto>(retailer);
        }

        private async Task<IEnumerable<RetailerDto>> GetRetailersFromWebAsync()
        {
            IList<RetailerDto> webRetailersDtoList = new List<RetailerDto>();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.opendata.esett.com/");
            IAsyncEnumerable<RetailerDto> webResponse = client.GetFromJsonAsAsyncEnumerable<RetailerDto>("EXP01/Retailers");

            await foreach (RetailerDto retailer in webResponse)
            {
                webRetailersDtoList.Add(retailer);
            }

            return webRetailersDtoList;
        }
    }
}
