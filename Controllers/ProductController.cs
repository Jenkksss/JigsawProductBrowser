using JigsawProductBrowser.Services;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly ProductService _service;
    private const int PageSize = 10;

    public ProductController(ProductService service) => _service = service;

    public async Task<IActionResult> Index(int page = 1)
    {
        try
        {
            int skip = (page - 1) * PageSize;
            var response = await _service.GetPagedProductsAsync(PageSize, skip);
            return View(response);
        }
        catch
        {
            return View("Error");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _service.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }
}