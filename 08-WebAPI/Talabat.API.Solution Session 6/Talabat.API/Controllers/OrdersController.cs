using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Services.Contract;

namespace Talabat.API.Controllers
{
    // [AllowAnonymous]            -> It's the default
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // Swagger Improvement : 

        [ProducesResponseType(typeof(OrderToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]    // POST:    baseURL/api/Orders
        public async Task<ActionResult<OrderToReturnDTO?>> CreateOrder(OrderDTO orderDTO)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var address = _mapper.Map<AddressDTO, Address>(orderDTO.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(buyerEmail, orderDTO.BasketId, orderDTO.DeliveryMethodId, address);

            if (order is null)
                return BadRequest(new ApiResponse(400));

            return Ok(_mapper.Map<OrderToReturnDTO>(order));
        }

        [HttpGet]                            // GET:  baseURL/api/orders
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrdersForUser(/*string email [Got from Token]*/)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetOrdersForUserAsync(buyerEmail);
            
            return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDTO>>(orders));
        }

        [ProducesResponseType(typeof(OrderToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]                       // GET:  baseURL/api/orders/1
        public async Task<ActionResult<OrderToReturnDTO>> GetSpecificOrderForUser(int id/*, string email*/)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetOrderByIdForUserAsync(id, buyerEmail);

            if (orders is null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<OrderToReturnDTO>(orders));
        }


        [AllowAnonymous]
        [HttpGet("deliveryMethods")]   // GET: baseURL/api/orders/deliveryMethods
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}


