using OMHRD.DAL;
using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.BL
{
    public class CartBL : ICartBL
    {
        private ICartRepository _cartRep;

        public CartBL()
        {
            _cartRep = new CartRepository();
        }

        public List<CartItemDTO> GetCartItems(int userId)
        {
            return _cartRep.GetCartItems(userId);
        }

        public CartDTO UpdateCart(CartItemDTO cart)
        {
            return _cartRep.UpdateCart(cart);
        }

        public CartDTO GetCartTotal(int userId)
        {
            return _cartRep.GetCartTotal(userId);
        }
    }
}
