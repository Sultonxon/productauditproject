

namespace ProductsProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IServiceProvider _serviceProvider;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,
             ApplicationDbContext context, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            /*_serviceProvider = serviceProvider;
            ApplicationDbContext
                .SeedData(_serviceProvider.GetRequiredService<UserManager<AppUser>>()
                , _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>()).Wait();*/

            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductHistory() => View(_productService.GetAuditLogs());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}