using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMHRD.Model;
using OMHRD.DAL;

namespace OMHRD.BL
{
    public class ProductBL : IProductBL
    {
        private IProductRepository _productRep;
        public ProductBL()
        {
            _productRep = new ProductRepository();
        }
        public List<ProductDTO> GetProducts(ProductSearchDTO searchDto)
        {
            var products = _productRep.GetProducts(searchDto);
            return products;
        }

        public ProductDTO GetProductById(int productId)
        {
            return _productRep.GetProductById(productId);
        }

    }
}
