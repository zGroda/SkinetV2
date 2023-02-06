using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketReporisoty;

        public BasketController(IBasketRepository basketReporisoty)
        {
            _basketReporisoty = basketReporisoty;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string basketId)
        {
            var basket = await _basketReporisoty.GetBasketAsync(basketId);
            return Ok(basket ?? new CustomerBasket(basketId));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketReporisoty.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string basketId)
        {
            await _basketReporisoty.DeleteBasketAsync(basketId);
        }
    }
}
