using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;
using TestApplication.Repository;

namespace TestApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository = null;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("all-books")]
        public async Task<ViewResult> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts();

            return View(data);
        }

        [Authorize(Roles = "User")]
        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }

        [HttpPost()]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _productRepository.AddNewProduct(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
                }
            }

            return View();
        }

        [Route("product-details/{id:int:min(1)}", Name = "productDetailsRoute")]
        public async Task<ViewResult> GetProduct(int id)
        {
            var data = await _productRepository.GetProductById(id);

            return View(data);
        }

    }
}