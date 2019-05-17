using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Server.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> productData = new List<ProductModel>();
        private int sequenceId = 1;

        public ProductRepository()
        {
            CreateProduct(new ProductModel { Name = "Banana", Category = "Fruit", Price = 5000 });
            CreateProduct(new ProductModel { Name = "Spinach", Category = "Vegetable", Price = 3000 });
            CreateProduct(new ProductModel { Name = "Candy", Category = "Snack", Price = 2000 });
        }

        public List<ProductModel> GetAllProduct()
        {
            var listData = productData.ToList();
            return listData;
        }

        public ProductModel GetProductById(int id)
        {
            var data = productData.Find(o => o.Id == id);

            if (data == null)
            {
                throw new ArgumentNullException("Product");
            }

            ProductModel product = data;
            return product;
        }

        public bool CreateProduct(ProductModel product)
        {
            try
            {
                if (product != null)
                {
                    product.Id = sequenceId++;
                    productData.Add(product);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
            
        }

        public bool UpdateProduct(ProductModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product");
            }
            else
            {
                int index = productData.FindIndex(o => o.Id == product.Id);
                if (index == -1)
                {
                    return false;
                }

                productData.RemoveAt(index);
                productData.Add(product);
                return true;
            }
        }

        public void DeleteProduct(int id)
        {
            productData.RemoveAll(o => o.Id == id);
        }
    }
}