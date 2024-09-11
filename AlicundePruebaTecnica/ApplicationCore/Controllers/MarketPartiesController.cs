using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlicundePruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/marketparties")]
    public class MarketPartiesController : ControllerBase
    {
        private readonly IMarketPartiesService _marketPartiesService;

        public MarketPartiesController(IMarketPartiesService marketPartiesService)
        {
            _marketPartiesService = marketPartiesService;
        }

        [HttpGet()]
        public ActionResult<int> GetAllAccounts()
        {
            try
            {
                IEnumerable<RetailerDto> response = _marketPartiesService.GetAllRetailers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}