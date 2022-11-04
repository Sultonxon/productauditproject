using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProductsProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            foreach (var item in products)
            {
                Console.WriteLine($"\n\n\n\n*****************ID = {item.Id}\n\n\n");
            }

            return View(products);
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, string returnUrl)
        {
            await _productService.CreateProduct(product);
            return Redirect(returnUrl);
        }

        public IActionResult Update(string id, string returnUrl)
        {
            Console.WriteLine("I***************************D"+id);
            ViewBag.ReturnUrl = returnUrl;
            return View(_productService.GetProduct(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product, string returnUrl)
        {
            await  _productService.UpdateProduct(product);
            return Redirect(returnUrl);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, string returnUrl)
        {
            await _productService.DeleteProduct(id);
            return Redirect(returnUrl);
        }
    }
}
