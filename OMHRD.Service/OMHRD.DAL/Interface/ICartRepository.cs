using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public interface ICartRepository
    {
        int InsertCart(Cart_T cart);

        CartDTO UpdateCart(CartItemDTO cart);

        List<CartItemDTO> GetCartItems(int userId);

        CartDTO GetCartTotal(int userId);
    }
}
