using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProductManagementWebApp.Models.DAL.Service
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(Guid id);
        ProductViewModel UpdateProduct(Guid id, ProductViewModel product);
        ProductViewModel AddProduct(ProductViewModel product); 
    }
    public class ProductService : IProductService
    {
        private static string baseUrl = "https://localhost:44317/api/";

        public List<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                //HTTP GET
                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    products = JsonConvert.DeserializeObject<List<ProductViewModel>>(readTask.Result);
                }
            }


            return products;
        }
        public ProductViewModel AddProduct(ProductViewModel product)
        {
            var productJson = GetStringAsync(baseUrl + "users/");
            //JsonConvert.DeserializeObject<ProductViewModel>(userJson);
            return default;
        }

        public ProductViewModel GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel UpdateProduct(Guid id, ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        private static Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return httpClient.GetStringAsync(url);
            }
        }
    }
}