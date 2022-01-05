namespace SortedCheckoutKata.Controllers
{
    using Application.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CheckOutController : ControllerBase
    {
        private readonly ILogger<CheckOutController> _logger;
        private readonly ICheckout _checkout;

        public CheckOutController(ILogger<CheckOutController> logger, ICheckout checkout)
        {
            _logger = logger;
            _checkout = checkout;
        }

        [HttpGet("GetTotalPrice", Name = "GetTotalPrice")]
        public IActionResult Get()
        {
            return Ok(_checkout.GetTotalPrice());
        }

        [HttpPost("ScanItem")]
        public IActionResult Post([FromBody] string sku)
        {
            _checkout.ScanItem(sku);

            return Ok();
        }
    }
}