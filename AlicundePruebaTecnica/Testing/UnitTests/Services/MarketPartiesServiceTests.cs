using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Profiles;
using Domain.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Json;
using Testing.Helpers;

namespace Testing.UnitTests.Services
{

    [TestClass]
    public class MarketPartiesServiceTests
    {
        private IMarketPartiesService _marketPartiesService;
        private Mock<IMarketPartiesRepository> _marketPartiesRepository;
        private static IMapper _autoMapper;
        private static Mock<IHttpClientFactory> _httpClientFactory;
        private static Mock<HttpMessageHandler> _httpMessageHandler;

        private int _reId;
        private Retailer _retailer;
        private IEnumerable<Retailer> _retailerList;
        private IEnumerable<RetailerDto> _retailerDtoList;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RetailerProfile());
            });

            _autoMapper = config.CreateMapper();
        }

        [TestInitialize]
        public void Init()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _marketPartiesRepository = new Mock<IMarketPartiesRepository>();
            _marketPartiesService = new MarketPartiesService(_marketPartiesRepository.Object, _autoMapper, _httpClientFactory.Object);
            _httpMessageHandler = new Mock<HttpMessageHandler>();

            _reId = ObjectHelper.ReId;
            _retailer = ObjectHelper.GetRetailer();
            _retailerList = ObjectHelper.GetRetailerList();
            _retailerDtoList = ObjectHelper.GetRetailerDtoList();
        }

        #region FillRetailers

        [TestMethod]
        public void FillRetailers_Success()
        {
            // First mock the MessageHandler inside HttpClient
            JsonContent content = JsonContent.Create(_retailerDtoList);
            _httpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = content,
                });

            // Then mock the actual Client with the handler
            HttpClient client = new HttpClient(_httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.opendata.esett.com/")
            };

            _httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            _marketPartiesRepository.Setup(x => x.FillRetailers(It.IsAny<IEnumerable<Retailer>>())).Returns(_retailerList);
            Task<IEnumerable<RetailerDto>> result = _marketPartiesService.FillRetailersAsync();

            IEnumerable<RetailerDto> retailerDtos = result.Result;

            Assert.AreEqual(_retailerList.FirstOrDefault().ReName, retailerDtos.FirstOrDefault().ReName);
            Assert.AreEqual(_retailerList.FirstOrDefault().ReCode, retailerDtos.FirstOrDefault().ReCode);
        }

        #endregion

        #region GetAllRetailers

        [TestMethod]
        public void GetAllRetailers_Success()
        {
            _marketPartiesRepository.Setup(x => x.GetAllRetailers()).Returns(_retailerList);
            IEnumerable<RetailerDto> result = _marketPartiesService.GetAllRetailers();

            Assert.AreEqual(_retailerList.FirstOrDefault().ReName, result.FirstOrDefault().ReName);
            Assert.AreEqual(_retailerList.FirstOrDefault().ReCode, result.FirstOrDefault().ReCode);
        }

        #endregion

        #region GetRetailer

        [TestMethod]
        public void GetRetailer_Success()
        {
            _marketPartiesRepository.Setup(x => x.GetRetailer(It.IsAny<int>())).Returns(_retailer);
            RetailerDto result = _marketPartiesService.GetRetailer(_reId);

            Assert.AreEqual(_retailer.ReName, result.ReName);
            Assert.AreEqual(_retailer.ReCode, result.ReCode);
        }

        #endregion

    }
}
