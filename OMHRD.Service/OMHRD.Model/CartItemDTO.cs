using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.Model
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int SizeId { get; set; }

        public string SizeCode { get; set; }

        public string SizeName { get; set; }

        public Nullable<int> ColorId { get; set; }

        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get { return (Price - Discount) * Quantity; } }

        public bool IsQuantityForAddition { get; set; }
    }
}
