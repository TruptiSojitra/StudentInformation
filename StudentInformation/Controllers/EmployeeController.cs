using StudentInformation.BusinessEntity;
using StudentInformation.Filter;
using StudentInformation.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace StudentInformation.Controllers
{
    [ValidateModelAttribute]
    public class EmployeeController : ApiController
    {
        public IProductService productService { get; set; }

        public EmployeeController(IProductService _productService)
        {
            productService = _productService;
        }
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var product = productService.GetProducts();

            IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            ContentNegotiationResult result = negotiator.Negotiate(
                typeof(ProductViewModel), this.Request, this.Configuration.Formatters);
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                throw new HttpResponseException(response);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<List<ProductViewModel>>(
                    product,                // What we are serializing 
                    result.Formatter,           // The media formatter
                    result.MediaType.MediaType  // The MIME type
                )
            };

            return Request.CreateResponse(HttpStatusCode.OK, productService.GetProducts());
        }

        // GET api/<controller>/5
        public ProductViewModel Get(int id)
        {
            var data = productService.GetProducts().Where(y=> y.ProductId == id).FirstOrDefault();
            return data;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] ProductViewModel productViewModel)
        {
            
                productService.AddProduct(productViewModel);

                return new HttpResponseMessage(HttpStatusCode.OK);
            
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] ProductViewModel productViewModel)
        {

             productService.UpdateProduct(productViewModel, id);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}