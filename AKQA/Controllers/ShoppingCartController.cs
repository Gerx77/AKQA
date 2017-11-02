using System;
using System.Web.Http;
using AKQA.Models;

namespace AKQA.Controllers
{
    public class ShoppingCartController : ApiController
    {

        public IHttpActionResult Post(ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                //Calculate the price in words
                shoppingCart.PriceInWords = NumbersToWords.ConvertToWords(shoppingCart.Price);

                return Ok(shoppingCart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
