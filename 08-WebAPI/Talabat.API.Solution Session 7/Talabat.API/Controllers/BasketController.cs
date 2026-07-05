using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Basket_Repository;

namespace Talabat.API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }


        [HttpGet]         // Get:  /api/Basket?id=         // id can also be sent as a segment
        public async Task<ActionResult<CustomerBasket>> GetBasket(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            return Ok( basket is null ? new CustomerBasket(basketId) : basket );
        }


        [HttpPost]        // Post:  /api/Basket
        public async Task<ActionResult<CustomerBasket>> UpdateCreateBasket(CustomerBasketDTO basket)
        {
            var createdUpdated = await _basketRepository.UpdateCreateBasketAsync(_mapper.Map<CustomerBasket>(basket));
            if (createdUpdated == null) 
                return BadRequest(new ApiResponse(400));
            return Ok(createdUpdated);
        }


        [HttpDelete]      // Delete:  /api/Basket
        public async Task<ActionResult<bool>> DeleteBasket(string basketId)
        {
            return await _basketRepository.DeleteBasketAsync(basketId);
        }
    }
}
