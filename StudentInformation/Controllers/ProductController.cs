using StudentInformation.BusinessEntity;
using StudentInformation.Models;
using StudentInformation.Service.Concrete;
using StudentInformation.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentInformation.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public IProductService productService { get; set; }

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [Route("getProduct/{id}")]
        [HttpGet]
        public List<ProductViewModel> getAllProduct(int id)
        {
            if (id < 500) 
            { 
            MyData myData = new MyData();

            myData.Data = new List<ProductViewModel>();

            }
            else
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID is = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }

            return productService.GetProducts();

             
        }

        [Route("addProduct")]
        [HttpPost]
        public bool addProductInfo([FromBody] ProductViewModel productViewModel)
        {
            return productService.AddProduct(productViewModel);
        }

        [Route("deleteProduct")]
        [HttpDelete]
        public bool deleteProductInfo(int productId)
        {
            return productService.DeleteProduct(productId);
        }

        [Route("updateProduct")]
        [HttpPut]
        public bool updateProductInfo([FromBody]ProductViewModel productViewModel,[FromUri]int productId)
        {
            return productService.UpdateProduct(productViewModel, productId);
        }
    }
}
