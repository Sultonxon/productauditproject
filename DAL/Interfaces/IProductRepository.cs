namespace ProductsProject.DAL.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();

    Product Get(string id);

    Task<bool> UpdateProduct(Product product, string userId);

    Task CreateProduct(Product product, string userId);
    
    Task DeleteProduct(string id, string userId);


    IEnumerable<Audit> ProductAudits { get; }
}
