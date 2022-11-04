namespace ProductsProject.DAL.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();

    Product Get(string id);

    Task UpdateProduct(Product product);

    Task CreateProduct(Product product);
    
    Task DeleteProduct(string id);


    IEnumerable<Audit> ProductAudits { get; }


    Task SaveChangesAsync(string userId);
}
