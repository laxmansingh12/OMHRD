using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public interface IProductRepository
    {
        /// <summary>
        /// Method to get products list
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <returns></returns>
        List<ProductDTO> GetProducts(ProductSearchDTO searchDto);

        ProductDTO GetProductById(int productId);
    }
}
