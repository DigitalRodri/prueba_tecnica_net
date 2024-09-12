using AlicundePruebaTecnica.Controllers;
using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Data;
using System;
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

        private int _reId;
        private RetailerDto _retailerDto;
        private RetailerDto _retailerDtoNull;
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

            _reId = ObjectHelper.ReId;
            _retailerDto = ObjectHelper.GetRetailerDto();
            _retailerDtoNull = null;
            _retailerDtoList = ObjectHelper.GetRetailerDtoList();
        }

        #region FillRetailers

        [TestMethod]
        public void FillRetailers_Success()
        {
            _marketPartiesService.Setup(x => x.FillRetailersAsync()).Returns(Task.FromResult(_retailerDtoList));
            ActionResult<IEnumerable<RetailerDto>> result = _marketPartiesController.FillRetailers();

            ObjectResult objectResult = result.Result as ObjectResult;
            Assert.AreEqual((int)HttpStatusCode.Created, objectResult.StatusCode);
            IEnumerable<RetailerDto> retailerDtoResult = objectResult.Value as IEnumerable<RetailerDto>;
            Assert.AreEqual(_retailerDto.ReName, retailerDtoResult.FirstOrDefault().ReName);
        }

        [TestMethod]
        public void FillRetailers_Exception()
        {
            _marketPartiesService.Setup(x => x.FillRetailersAsync()).Throws(new Exception());
            ActionResult<IEnumerable<RetailerDto>> result = _marketPartiesController.FillRetailers();

            ObjectResult objectResult = result.Result as ObjectResult;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion

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

        #region GetRetailer

        [TestMethod]
        public void GetRetailer_Success()
        {
            _marketPartiesService.Setup(x => x.GetRetailer(It.IsAny<int>())).Returns(_retailerDto);
            ActionResult<RetailerDto> result = _marketPartiesController.GetRetailer(_reId);

            OkObjectResult objectResult = result.Result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            RetailerDto retailerDtoResult = objectResult.Value as RetailerDto;
            Assert.AreEqual(_retailerDto.ReName, retailerDtoResult.ReName);
        }

        [TestMethod]
        public void GetRetailer_NoContent()
        {
            _marketPartiesService.Setup(x => x.GetRetailer(It.IsAny<int>())).Returns(_retailerDtoNull);
            ActionResult<RetailerDto> result = _marketPartiesController.GetRetailer(_reId);

            NoContentResult noContentResult = result.Result as NoContentResult;
            Assert.AreEqual((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [TestMethod]
        public void GetRetailer_Exception()
        {
            _marketPartiesService.Setup(x => x.GetRetailer(It.IsAny<int>())).Throws(new Exception());
            ActionResult<RetailerDto> result = _marketPartiesController.GetRetailer(_reId);

            ObjectResult objectResult = result.Result as ObjectResult;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion
    }
}
