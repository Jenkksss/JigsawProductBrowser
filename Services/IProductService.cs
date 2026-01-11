using JigsawProductBrowser.Models;

namespace JigsawProductBrowser.Services
{
    public interface IProductService
    {
        Task<ProductResponse?> GetPagedProductsAsync(int limit, int skip);

        Task<Product?> GetProductByIdAsync(int id);
    }
}