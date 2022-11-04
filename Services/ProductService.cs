namespace ProductsProject.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateProduct(Product product, string userId)
    {
        await _repository.CreateProduct(product, userId);
    }

    public async Task DeleteProduct(string id, string userId)
    {
        await _repository.DeleteProduct(id, userId);
    }

    public Product GetProduct(string id) => _repository.Get(id);

    public IEnumerable<Product> GetProducts() => _repository.GetProducts();

    public async Task UpdateProduct(Product product, string userId)
    {
        await _repository.UpdateProduct(product, userId);
    }

    public IEnumerable<Audit> GetAuditLogs() => _repository.ProductAudits;
}
