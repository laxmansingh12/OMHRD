using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.Model
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string HSN { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public List<string> SizeList { get; set; }

        public List<string> ColorList { get; set; }

        public List<ProductPriceDTO> PriceList {get;set;}
    }
}
