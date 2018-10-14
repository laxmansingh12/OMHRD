using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.BL
{
    public interface IProductBL
    {
        /// <summary>
        /// Method to get products list
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        List<ProductDTO> GetProducts(ProductSearchDTO searchDto);

        ProductDTO GetProductById(int productId);
    }
}
