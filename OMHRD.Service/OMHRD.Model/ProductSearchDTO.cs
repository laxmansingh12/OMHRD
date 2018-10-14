using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.Model
{
    public class ProductSearchDTO
    {
       public string Code { get; set; }

       public string Name { get; set; }

       public string HSN { get; set; }

       public decimal MinPrice { get; set; }

       public decimal MaxPrice { get; set; }

       public int CategoryId { get; set; }

       public int SubCategoryId { get; set; }
    }
}
