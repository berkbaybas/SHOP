﻿using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<ShoppingCart> GetBasket(string userName)
        {
            string basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket)) 
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
            
        }

        public Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
