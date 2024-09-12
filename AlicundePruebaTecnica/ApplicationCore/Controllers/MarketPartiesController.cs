using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
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

        [HttpPost()]
        public ActionResult<IEnumerable<RetailerDto>> FillRetailers()
        {
            try
            {
                IEnumerable<RetailerDto> retailersDtoList = _marketPartiesService.FillRetailersAsync().Result;

                return Created(new Uri(Request.GetEncodedUrl()), retailersDtoList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet()]
        public ActionResult<IEnumerable<RetailerDto>> GetAllRetailers()
        {
            try
            {
                IEnumerable<RetailerDto> retailersDtoList = _marketPartiesService.GetAllRetailers();
                return Ok(retailersDtoList);
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
                RetailerDto retailerDto = _marketPartiesService.GetRetailer(reId);

                if (retailerDto == null) return NoContent();
                return Ok(retailerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}