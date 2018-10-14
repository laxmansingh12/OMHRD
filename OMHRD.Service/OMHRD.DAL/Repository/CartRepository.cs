using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public class CartRepository : ICartRepository
    {
        public CartRepository()
        {
        }

        public int InsertCart(Cart_T cart)
        {
            using (var dbContext = new OMHRDModel())
            {
                dbContext.Cart_T.Add(cart);
                return dbContext.SaveChanges();
            }
        }

        public CartDTO UpdateCart(CartItemDTO cart)
        {
            using (var dbContext = new OMHRDModel())
            {
                var cartItem = dbContext.Cart_T.FirstOrDefault(x => x.ProductId == cart.ProductId && x.UserId == cart.UserId && x.SizeId == cart.SizeId && (!x.ColorId.HasValue || x.ColorId.Value == cart.ColorId.Value));
                if (cartItem != null)
                {
                    cartItem.Quantity = cart.IsQuantityForAddition ? cartItem.Quantity + cart.Quantity : cart.Quantity;
                    dbContext.SaveChanges();
                }
                else
                {
                    cartItem = new Cart_T()
                    {
                        ProductId = cart.ProductId,
                        ColorId = cart.ColorId,
                        SizeId = cart.SizeId,
                        Quantity = cart.Quantity,
                        UserId = cart.UserId
                    };
                    dbContext.Cart_T.Add(cartItem);
                    dbContext.SaveChanges();

                }
                return GetCartTotal(cart.UserId);
            }
        }

        public List<CartItemDTO> GetCartItems(int userId)
        {
            using (var dbContext = new OMHRDModel())
            {
                var cartItems = (from cart in dbContext.Cart_T
                                 join price in dbContext.ProductPrice_T on new { ProductId = cart.ProductId, SizeId = cart.SizeId, ColorId = cart.ColorId } equals new { price.ProductId, SizeId = price.ProductSizeId, ColorId = price.ProductColorId }
                                 join prodcut in dbContext.Product_T on cart.ProductId equals prodcut.Id
                                 where cart.UserId == userId
                                 select new CartItemDTO
                                 {
                                     Id = cart.Id,
                                     ColorId = cart.ColorId,
                                     ColorName = cart.ColorId.HasValue ? cart.ProductColor_T.Name : "",
                                     ColorCode = cart.ColorId.HasValue ? cart.ProductColor_T.Code : "",
                                     Price = price.Price - price.Discount,
                                     Discount = price.Discount,
                                     ProductId = prodcut.Id,
                                     ProductName = prodcut.Name,
                                     Quantity = cart.Quantity,
                                     SizeId = cart.SizeId,
                                     SizeName = cart.ProductSize_T.Name,
                                     SizeCode = cart.ProductSize_T.Code,
                                     UserId = userId
                                 }).ToList();

                return cartItems;
            }
        }

        public CartDTO GetCartTotal(int userId)
        {
            using (var dbContext = new OMHRDModel())
            {
                var cartItems = (from cartDB in dbContext.Cart_T
                                 join price in dbContext.ProductPrice_T on new { ProductId = cartDB.ProductId, SizeId = cartDB.SizeId, ColorId = cartDB.ColorId } equals new { price.ProductId, SizeId = price.ProductSizeId, ColorId = price.ProductColorId }
                                 join prodcut in dbContext.Product_T on cartDB.ProductId equals prodcut.Id
                                 where cartDB.UserId == cartDB.UserId
                                 select new
                                 {
                                     Price = (price.Price - price.Discount) * cartDB.Quantity,
                                     Quantity = cartDB.Quantity
                                 });

                return new CartDTO { TotalPrice = cartItems.Sum(x => x.Price), Quantity = cartItems.Sum(x => x.Quantity) };
            }
        }
    }
}
