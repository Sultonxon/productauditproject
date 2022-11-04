

using FluentValidation;
using ProductsProject.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("TestDB");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => 
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.Services.AddMvc(o => o.EnableEndpointRouting = false);
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

/*app.UseMvc(routes =>
{

    routes.MapRoute("default", "/", new { controller = "Home", action = "Index" });
    routes.MapRoute("all", "{controller}/{action}");

    routes.MapRoute("area", "Identity/Account/Login",
        new { area = "Identity", controller = "Account", action = "Login" });
});*/

app.Run();
