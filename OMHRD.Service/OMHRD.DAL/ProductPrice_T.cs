//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMHRD.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductPrice_T
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductSizeId { get; set; }
        public Nullable<int> ProductColorId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    
        public virtual Product_T Product_T { get; set; }
        public virtual ProductColor_T ProductColor_T { get; set; }
        public virtual ProductSize_T ProductSize_T { get; set; }
    }
}
