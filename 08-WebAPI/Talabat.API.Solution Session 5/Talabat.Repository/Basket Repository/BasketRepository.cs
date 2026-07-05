using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Repositories.Contract;

namespace Talabat.Repository.Basket_Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var basket = await _redis.StringGetAsync(basketId);

            // it's returned as RedisValue , so we must convert it to CustomerBasket (it's now JSON)
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);

        }

        public async Task<CustomerBasket?> UpdateCreateBasketAsync(CustomerBasket basket)
        {
            var CreatedOrUpdated = await _redis.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!CreatedOrUpdated)
                return null;
            return await GetBasketAsync(basket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _redis.KeyDeleteAsync(basketId);
        }
    }
}
