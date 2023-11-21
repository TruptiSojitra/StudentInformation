using StudentInformation.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.Repository.Interface
{
    /// <summary>
    /// Product Info
    /// </summary>
    public interface IProductRepository
    {
        List<Product> GetProducts();

        bool AddProduct(Product product);

        bool deleteProduct (int productId);

        bool UpdateProduct (Product product, int productId);
    }
}
