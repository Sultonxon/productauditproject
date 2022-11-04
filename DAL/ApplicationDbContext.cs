

namespace ProductsProject.DAL
{
    public class ApplicationDbContext : AuditableIdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<IdentityRole>().HasData(new IdentityRole("Admin"), new IdentityRole("User"));
        }


        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            await userManager.CreateAsync(new AppUser { UserName = "Admin", Email = "admin@gmail.com" }, 
                                                        "Secret123$");
            var user = await userManager.FindByNameAsync("Admin");
            userManager.AddToRoleAsync(user, "Admin");
            userManager.AddToRoleAsync(user, "User");
            

            
        }
    }
}