namespace ProductsProject.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void CreateProduct(Product product)
    {
        _repository.CreateProduct(product);
    }

    public void DeleteProduct(string id)
    {
        _repository.DeleteProduct(id);
    }

    public Product GetProduct(string id) => _repository.Get(id);

    public IEnumerable<Product> GetProducts() => _repository.GetProducts();

    public void UpdateProduct(Product product)
    {
        _repository.UpdateProduct(product);
    }

    public IEnumerable<Audit> GetAuditLogs() => _repository.ProductAudits;
}
