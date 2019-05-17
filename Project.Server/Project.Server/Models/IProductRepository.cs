using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Server.Models
{
    public interface IProductRepository
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProductById(int id);
        bool CreateProduct(ProductModel product);
        bool UpdateProduct(ProductModel product);
        void DeleteProduct(int id);
    }
}
