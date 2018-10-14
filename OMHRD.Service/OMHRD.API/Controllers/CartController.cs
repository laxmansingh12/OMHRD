using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMHRD.Model;
using OMHRD.BL;

namespace OMHRD.API.Controllers
{
    //[OMHRDAuthorize]
    [RoutePrefix("cart")]
    public class CartController : ApiController
    {
        private ICartBL _cartBL;
        public CartController()
        {
            _cartBL = new CartBL();
        }

        [HttpGet]
        [Route("items/userid/{userId}")]
        public IHttpActionResult GetCartItems(int userId)
        {
            var result = _cartBL.GetCartItems(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("total/userid/{userId}")]
        public HttpResponseMessage GetCartTotal(int userId)
        {
            var result = _cartBL.GetCartTotal(userId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, HttpPost]
        [Route("addtocart")]
        public HttpResponseMessage UpdateCart(CartItemDTO cartItem)
        {
            var result = _cartBL.UpdateCart(cartItem);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
    }
}
