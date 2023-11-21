using StudentInformation.DomainEntity;
using StudentInformation.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Products.Add(product);

                return northwindEntities.SaveChanges() > 0 ? true : false;

            }
            return false;
        }

        public bool deleteProduct(int productId)
        {
            Product product = new Product();
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                product = northwindEntities.Products.Where(y=> y.ProductID == productId).FirstOrDefault();
                northwindEntities.Products.Remove(product);
                return northwindEntities.SaveChanges() > 0? true : false;


            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                products = northwindEntities.Products.ToList();

            }
            return products;
        }

        public bool UpdateProduct(Product product, int productId)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            { 
                var myInnerData = northwindEntities.Products.Where(y=> y.ProductID== productId).FirstOrDefault();
                myInnerData.ProductName = product.ProductName;
                return northwindEntities.SaveChanges() > 0? true : false;

            }
        }
    }
}
