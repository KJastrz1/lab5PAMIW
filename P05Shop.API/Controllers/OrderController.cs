using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P06Shop.Shared;
using P06Shop.Shared.Services.OrderService;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService OrderService, ILogger<OrderController> logger)
        {
            _OrderService = OrderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Order>>>> GetOrders()
        {
            _logger.Log(LogLevel.Information, "Invoked GetOrders Method in controller");
            var result = await _OrderService.GetOrdersAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Order>>> GetOrder(int id)
        {
            var result = await _OrderService.GetOrderByIdAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Order>>> UpdateOrder([FromBody] Order Order)
        {
            _logger.Log(LogLevel.Critical, "Invoked UpdateOrder Method in controller");
            var result = await _OrderService.UpdateOrderAsync(Order);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Order>>> CreateOrder([FromBody] Order Order)
        {
            var result = await _OrderService.CreateOrderAsync(Order);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteOrder([FromRoute] int id)
        {
            var result = await _OrderService.DeleteOrderAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }
    }
}
