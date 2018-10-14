using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMHRD.Model;
using OMHRD.BL;

namespace OMHRD.API.Controllers
{
    //[OMHRDAuthorize]
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private IProductBL _productBL;
        public ProductController()
        {
            _productBL = new ProductBL();
        }


        [HttpPost]
        [Route("search")]
        public HttpResponseMessage GetProducts(ProductSearchDTO searchDto)
        {
            searchDto = searchDto ?? new ProductSearchDTO();
            var products = _productBL.GetProducts(searchDto);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("search/categoryid/{categoryId}")]
        public HttpResponseMessage GetProductByCategory(int categoryId)
        {
            var searchDto = new ProductSearchDTO();
            searchDto.CategoryId = categoryId;
            var products = _productBL.GetProducts(searchDto);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("byid/{productId}")]
        public HttpResponseMessage GetProductById(int productId)
        {
            var product = _productBL.GetProductById(productId);
            product.SizeList = product.PriceList.Select(x=>x.SizeCode).Distinct().ToList();
            product.ColorList = product.PriceList.Where(x=> !string.IsNullOrEmpty(x.ColorCode)).Select(x => x.ColorCode).Distinct().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

    }
}
