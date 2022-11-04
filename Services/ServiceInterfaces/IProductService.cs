namespace ProductsProject.Services.ServiceInterfaces;

public interface IProductService
{
    Product GetProduct(string id);

    IEnumerable<Product> GetProducts();

    void CreateProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(string id);

    IEnumerable<Audit> GetAuditLogs();
}
