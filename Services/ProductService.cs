using JigsawProductBrowser.Models;

namespace JigsawProductBrowser.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://dummyjson.com/");
        }

        public async Task<ProductResponse?> GetPagedProductsAsync(int limit, int skip)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductResponse>($"products?limit={limit}&skip={skip}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Product>($"products/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}