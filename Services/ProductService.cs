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
                var response = await _httpClient.GetAsync($"products/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product {id}: {ex.Message}");
                return null;
            }
        }
    }
}