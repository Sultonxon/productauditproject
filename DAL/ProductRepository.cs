﻿namespace ProductsProject.DAL;

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

    public async Task UpdateProduct(Product product)
    {
        Product entity = _context.Products.FirstOrDefault(x => x.Id == product.Id);
        if(entity is null)
        {
            return;
        }
        entity.Name = product.Name;
        entity.Price = product.Price;
    }

    public async Task CreateProduct(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        _context.Products.Add(product);
    }

    public async Task DeleteProduct(string id)
    {
        _context.Products.Remove(new Product { Id = id });
    }

    public async Task SaveChangesAsync(string userId)
    {
        await _context.SaveChangesAsync(userId);
    }

    public IEnumerable<Audit> ProductAudits => _context.AuditLogs.ToList();


}
