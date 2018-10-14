using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.Model
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }

        public int SizeId { get; set; }

        public string SizeCode { get; set; }

        public string SizeName { get; set; }

        public int? ColorId { get; set; }

        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        
        public decimal DiscountedPrice { get { return Price - Discount; } }
    }
}
