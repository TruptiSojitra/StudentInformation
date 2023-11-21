using StudentInformation.BusinessEntity;
using StudentInformation.Repository.Concrete;
using StudentInformation.Repository.Interface;
using StudentInformation.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformation.DomainEntity;

namespace StudentInformation.Service.Concrete
{
    public class ProductService : IProductService
    {
        public IProductRepository productRepository { get; set; }
        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public List<ProductViewModel> GetProducts()
        {
           
            var myData = productRepository.GetProducts();

            var myNewData = myData.Select(y=> new ProductViewModel
            {
                ProductDescription= y.ProductName,
                ProductName= y.ProductName,
                ProductId= y.ProductID

            }).ToList();
            return myNewData;
        }

        public bool AddProduct(ProductViewModel productViewModel)
        {
            Product product = new Product();
            product.ProductID = productViewModel.ProductId;
            product.ProductName = productViewModel.ProductName;


            return productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return productRepository.deleteProduct(productId);
        }

        public bool UpdateProduct(ProductViewModel productViewModel, int productId)
        {
            var product = new Product();
            product.ProductName = productViewModel.ProductName;
            product.ProductID = productViewModel.ProductId;

            return productRepository.UpdateProduct(product,productId);
        }
    }
}
