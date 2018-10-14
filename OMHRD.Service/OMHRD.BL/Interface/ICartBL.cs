using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.BL
{
    public interface ICartBL
    {
        CartDTO UpdateCart(CartItemDTO cart);

        List<CartItemDTO> GetCartItems(int userId);

        CartDTO GetCartTotal(int userId);
    }
}
