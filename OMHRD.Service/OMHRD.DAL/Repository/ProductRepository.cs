using OMHRD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMHRD.DAL
{
    public class ProductRepository : IProductRepository
    {
        private OMHRDModel dbContext;

        public ProductRepository()
        {
        }

        public List<ProductDTO> GetProducts(ProductSearchDTO searchDto)
        {
            using (dbContext = new OMHRDModel())
            {
                var products = dbContext.Product_T.Where(x => (searchDto.SubCategoryId == 0 || x.SubCategoryId == searchDto.SubCategoryId) && (searchDto.CategoryId == 0 || x.ProductSubCategory_T.CategoryId == searchDto.CategoryId))
                    .Select(x => new ProductDTO
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        HSN = x.HSN,
                        ShortDescription = x.Description,
                        Description = x.Description,
                        PriceList = x.ProductPrice_T.Select(y => new ProductPriceDTO
                        {
                            Price = y.Price,
                            Discount = y.Discount,
                            Quantity = y.Quantity,
                            SizeId = y.ProductSizeId,
                            SizeCode = y.ProductSize_T.Code,
                            ColorId = y.ProductColorId,
                            ColorCode = y.ProductColorId == null ? y.ProductColor_T.Code : string.Empty
                        }).ToList()
                    }).ToList();

                return products;
            }
        }

        public ProductDTO GetProductById(int productId)
        {
            using (dbContext = new OMHRDModel())
            {
                using (dbContext = new OMHRDModel())
                {
                    var product = dbContext.Product_T.Where(x => (x.Id == productId))
                        .Select(x => new ProductDTO
                        {
                            Id = x.Id,
                            Code = x.Code,
                            Name = x.Name,
                            HSN = x.HSN,
                            ShortDescription = x.Description,
                            Description = x.Description,
                            PriceList = x.ProductPrice_T.Select(y => new ProductPriceDTO
                            {
                                Id = y.Id,
                                Price = y.Price,
                                Discount = y.Discount,
                                Quantity = y.Quantity,
                                SizeId = y.ProductSizeId,
                                SizeCode = y.ProductSize_T.Code,
                                SizeName = y.ProductSize_T.Name,
                                ColorId = y.ProductColorId,
                                ColorCode = y.ProductColorId != null ? y.ProductColor_T.Code : string.Empty,
                                ColorName = y.ProductColorId != null ? y.ProductColor_T.Name : string.Empty
                            }).ToList()
                        }).FirstOrDefault();

                    return product;
                }
            }
        }
    }
}
