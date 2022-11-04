namespace ProductsProject.Services.ServiceInterfaces;

public interface IProductService
{
    Product GetProduct(string id);

    IEnumerable<Product> GetProducts();

    Task CreateProduct(Product product);

    Task UpdateProduct(Product product);

    Task DeleteProduct(string id);

    IEnumerable<Audit> GetAuditLogs();
}
