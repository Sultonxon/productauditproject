namespace ProductsProject.DAL.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();

    Product Get(string id);

    bool UpdateProduct(Product product);

    void CreateProduct(Product product);
    
    void DeleteProduct(string id);


    IEnumerable<Audit> ProductAudits { get; }
}
