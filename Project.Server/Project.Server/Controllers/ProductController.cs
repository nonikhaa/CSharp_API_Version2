using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Server.Models;
using Project.Server.Common;
using Newtonsoft.Json;

namespace Project.Server.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        [HttpGet]
        public List<ProductModel> GetAllProduct()
        {
            try
            {
                var product = repository.GetAllProduct();
                return product;
            }
            catch
            {
                throw new ArgumentNullException("Product");
            }
        }

        [HttpGet]
        public ProductModel GetProductById(int id)
        {
            var product = repository.GetProductById(id);
            return product;
        }

        [HttpPost]
        public ResponseModel CreateProduct(ProductModel product)
        {
            bool prd = repository.CreateProduct(product);
            ResponseModel response = new ResponseModel();

            if (prd == true)
            {
                response.Code = (int)EnumResponseStatus.Success;
                response.Description = EnumResponseStatus.Success.ToString();
            }
            else
            {
                response.Code = (int)EnumResponseStatus.Failed;
                response.Description = EnumResponseStatus.Failed.ToString();
            }

            return response;
        }
    }
}
