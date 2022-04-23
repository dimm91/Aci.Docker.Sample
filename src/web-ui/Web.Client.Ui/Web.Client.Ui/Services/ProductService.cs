using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Client.Ui.Services
{
    public record Product(Guid Id, string Name, string Description, decimal Price);

    public class ProductService
    {
        private readonly IConfiguration _config;

        public string ApiHost { get; private set; }

        public ProductService(IConfiguration config)
        {
            _config = config;
            ApiHost = _config["ProductApiConfig:Host"];
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var request = new FlurlRequest($"http://{ApiHost}/api/product/getProducts");
            var response = await request.GetJsonAsync<IEnumerable<Product>>();
            return response;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var request = new FlurlRequest($"http://{ApiHost}/api/product/getProduct/{id}");
            var response = await request.GetJsonAsync<Product>();
            return response;
        }
    }
}
