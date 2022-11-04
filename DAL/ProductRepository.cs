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

    public async Task<bool> UpdateProduct(Product product, string userId)
    {
        Product entity = _context.Products.FirstOrDefault(x => x.Id == product.Id);
        if(entity is null)
        {
            return false;
        }
        entity.Name = product.Name;
        entity.Price = product.Price;
        return await _context.SaveChangesAsync(userId) > 0;
    }

    public async Task CreateProduct(Product product, string userId)
    {
        product.Id = Guid.NewGuid().ToString();
        _context.Products.Add(product);
        await _context.SaveChangesAsync(userId);
    }

    public async Task DeleteProduct(string id, string userId)
    {
        _context.Products.Remove(new Product { Id = id });
        await _context.SaveChangesAsync(userId);
    }

    public IEnumerable<Audit> ProductAudits => _context.AuditLogs.ToList();
}
