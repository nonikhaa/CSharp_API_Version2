using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace Project.client
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            ShowListProduct("http://localhost:9853/api/product/");

            Console.ReadLine();
        }

        static void ShowProduct(Product product)
        {
            Console.WriteLine("Name     : " + product.Name);
            Console.WriteLine("Price    : " + product.Price);
            Console.WriteLine("Category : " + product.Category);
            Console.WriteLine(System.Environment.NewLine);
        }

        static void ShowListProduct(string path)
        {
            var listPrd = GetAllProduct(path);

            Console.WriteLine("============LIST PRODUCT============");
            foreach (var detail in listPrd)
            {
                Console.WriteLine("Name     : " + detail.Name);
                Console.WriteLine("Price    : " + detail.Price);
                Console.WriteLine("Category : " + detail.Category);
            }
            Console.WriteLine("============LIST PRODUCT============");
        }

        /// <summary>
        /// Get all product
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static List<Product> GetAllProduct(string path)
        {
            try
            {
                List<Product> listPrd = new List<Product>();

                HttpWebRequest GetRequest = (HttpWebRequest)WebRequest.Create(path);
                GetRequest.Method = "GET";

                HttpWebResponse GetResponse = (HttpWebResponse)GetRequest.GetResponse();
                Stream GetResponseStream = GetResponse.GetResponseStream();
                StreamReader sr = new StreamReader(GetResponseStream);
                string strResponse = sr.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Product>>(strResponse);
            }
            catch { throw; }
        }
    }
}
