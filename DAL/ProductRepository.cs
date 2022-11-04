namespace ProductsProject.DAL;

public class ProductRepository : IProductRepository
{ 
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public IEnumerable<Product> GetProducts() => _context.Products.ToList();

    public Product Get(string id)
    {
        var p = _context.Products.FirstOrDefault(x => x.Id == id);
        return p;
    }

    public bool UpdateProduct(Product product)
    {
        Product entity = _context.Products.FirstOrDefault(x => x.Id == product.Id);
        if(entity is null)
        {
            return false;
        }
        entity.Name = product.Name;
        entity.Price = product.Price;
        return _context.SaveChanges() > 0;
    }

    public void CreateProduct(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(string id)
    {
        _context.Products.Remove(new Product { Id = id });
        _context.SaveChanges();
    }

    public IEnumerable<Audit> ProductAudits => _context.AuditLogs.ToList();
}
