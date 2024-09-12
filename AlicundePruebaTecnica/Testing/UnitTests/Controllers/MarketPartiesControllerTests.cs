using AlicundePruebaTecnica.Controllers;
using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Testing.Helpers;

namespace Testing.UnitTests.Controllers
{
    [TestClass]
    public class MarketPartiesControllerTests
    {
        private MarketPartiesController _marketPartiesController;
        private Mock<IMarketPartiesService> _marketPartiesService;
        private Mock<HttpRequest> _httpRequest;
        private HttpContext _httpContext;
        private ControllerContext _controllerContext;

        private IEnumerable<RetailerDto> _retailerDtoList;

        [TestInitialize]
        public void Init()
        {
            _marketPartiesService = new Mock<IMarketPartiesService>();
            _httpRequest = new Mock<HttpRequest>();

            _httpRequest.Setup(x => x.Scheme).Returns("http");
            _httpRequest.Setup(x => x.Host).Returns(HostString.FromUriComponent("localhost:8080"));
            _httpRequest.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            _httpContext = Mock.Of<HttpContext>(x => x.Request == _httpRequest.Object);
            _controllerContext = new ControllerContext() { HttpContext = _httpContext };

            _marketPartiesController = new MarketPartiesController(_marketPartiesService.Object) { ControllerContext = _controllerContext };

            _retailerDtoList = ObjectHelper.GetRetailerDtoList();
        }

        #region GetAllRetailers

        [TestMethod]
        public void GetAllRetailers_Success()
        {
            _marketPartiesService.Setup(x => x.GetAllRetailers()).Returns(_retailerDtoList);
            ActionResult<IEnumerable<RetailerDto>> result = _marketPartiesController.GetAllRetailers();

            OkObjectResult objectResult = result.Result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            IEnumerable<RetailerDto> retailerDtoResult = objectResult.Value as IEnumerable<RetailerDto>;
            Assert.IsTrue(retailerDtoResult.Count() > 0);
        }

        [TestMethod]
        public void GetAllRetailers_Exception()
        {
            _marketPartiesService.Setup(x => x.GetAllRetailers()).Throws(new Exception());
            ActionResult<IEnumerable<RetailerDto>> result = _marketPartiesController.GetAllRetailers();

            ObjectResult objectResult = result.Result as ObjectResult;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion
    }
}
