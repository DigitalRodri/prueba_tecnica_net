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
        public ActionResult<int> GetAllRetailers()
        {
            try
            {
                IEnumerable<RetailerDto> retailerDTOList = _marketPartiesService.GetAllRetailers();
                return Ok(retailerDTOList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{reId}")]
        public ActionResult<RetailerDto> GetRetailer(int reId)
        {
            try
            {
                RetailerDto retailerDTO = _marketPartiesService.GetRetailer(reId);

                if (retailerDTO == null) return NoContent();
                return Ok(retailerDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}