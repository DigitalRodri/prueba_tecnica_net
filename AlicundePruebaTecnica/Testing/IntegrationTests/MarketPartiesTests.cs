using Domain.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Testing.IntegrationTests
{
    [TestClass]
    public class MarketPartiesTests : WebApplicationFactory<Program>
    {
        private static TestContext s_testContext;
        private static WebApplicationFactory<Program> s_factory;
        private static HttpClient s_httpClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            s_testContext = testContext;
            s_factory = new WebApplicationFactory<Program>();

            s_httpClient = s_factory.CreateClient();
        }

        [TestMethod]
        public async Task Create_Get_Update_Delete_Account_OK()
        {
            s_testContext.WriteLine(s_testContext.TestName);

            // POST Retailer

            HttpResponseMessage fillRetailersResponse = await s_httpClient.PostAsJsonAsync("api/marketparties", 0);
            Assert.AreEqual(HttpStatusCode.Created, fillRetailersResponse.StatusCode);

            string fillRetailersResponseString = await fillRetailersResponse.Content.ReadAsStringAsync();
            var retailersDtoList = JsonConvert.DeserializeObject<IEnumerable<RetailerDto>>(fillRetailersResponseString);
            Assert.IsTrue(retailersDtoList.Count() > 0);
            Assert.IsNotNull(retailersDtoList.FirstOrDefault().ReName);
            Assert.IsNotNull(retailersDtoList.FirstOrDefault().Country);

            // GET Retailer

            HttpResponseMessage getRetailerResponse = await s_httpClient.GetAsync("api/marketparties/" + retailersDtoList.FirstOrDefault().ReId);
            Assert.AreEqual(HttpStatusCode.OK, getRetailerResponse.StatusCode);

            string getRetailerResponseString = await getRetailerResponse.Content.ReadAsStringAsync();
            var retailerDto = JsonConvert.DeserializeObject<RetailerDto>(getRetailerResponseString);
            Assert.AreEqual(retailersDtoList.FirstOrDefault().ReName, retailerDto.ReName);
            Assert.AreEqual(retailersDtoList.FirstOrDefault().Country, retailerDto.Country);
            Assert.AreEqual(retailersDtoList.FirstOrDefault().CodingScheme, retailerDto.CodingScheme);
        }

        [TestMethod]
        public async Task Get_Retailer_NoContent()
        {
            s_testContext.WriteLine(s_testContext.TestName);

            HttpResponseMessage getRetailerResponse = await s_httpClient.GetAsync("api/marketparties/" + 123456);
            Assert.AreEqual(HttpStatusCode.NoContent, getRetailerResponse.StatusCode);
        }

        [TestMethod]
        public async Task Get_AllRetailers_OK()
        {
            s_testContext.WriteLine(s_testContext.TestName);

            HttpResponseMessage getRetailerResponse = await s_httpClient.GetAsync("api/marketparties/");
            Assert.AreEqual(HttpStatusCode.OK, getRetailerResponse.StatusCode);

            string getRetailerResponseString = await getRetailerResponse.Content.ReadAsStringAsync();
            var retailersDtoList = JsonConvert.DeserializeObject<IEnumerable<RetailerDto>>(getRetailerResponseString);
            Assert.IsTrue(retailersDtoList.Count() > 0);
            Assert.IsNotNull(retailersDtoList.FirstOrDefault().ReName);
            Assert.IsNotNull(retailersDtoList.FirstOrDefault().Country);
        }
    }
}
