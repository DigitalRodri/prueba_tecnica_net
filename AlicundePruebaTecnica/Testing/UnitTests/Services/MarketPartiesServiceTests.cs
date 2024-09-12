using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Profiles;
using Domain.Services;
using Moq;
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

        private IEnumerable<Retailer> _retailerList;

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

            _retailerList = ObjectHelper.GetRetailerList();
        }

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

    }
}
