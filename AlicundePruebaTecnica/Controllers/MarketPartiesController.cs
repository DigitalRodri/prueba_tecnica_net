using Microsoft.AspNetCore.Mvc;

namespace AlicundePruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/marketparties")]
    public class MarketPartiesController : ControllerBase
    {

        [HttpGet()]
        public ActionResult<int> GetAllAccounts()
        {
            try
            {
                return Ok(1234);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}