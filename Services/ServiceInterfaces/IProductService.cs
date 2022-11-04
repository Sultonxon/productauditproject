namespace ProductsProject.Services.ServiceInterfaces;

public interface IProductService
{
    Product GetProduct(string id);

    IEnumerable<Product> GetProducts();

    Task CreateProduct(Product product, string userId);

    Task UpdateProduct(Product product, string userId);

    Task DeleteProduct(string id, string userId);

    IEnumerable<Audit> GetAuditLogs();
}
