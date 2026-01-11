namespace JigsawProductBrowser.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
    public string ShippingInformation { get; set; } = string.Empty;
}

public class ProductResponse
{
    public List<Product> Products { get; set; } = new();
    public int Total { get; set; }
    public int Skip { get; set; }
    public int Limit { get; set; }
}