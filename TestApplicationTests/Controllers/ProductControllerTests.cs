using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestApplication.Repository;
using TestApplication.Models;
using Assert = NUnit.Framework.Assert;

namespace TestApplication.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {
        [Test()]
        public async Task GetAllProductsTest()
        {
            // arrange
            var repo = new Mock<IProductRepository>();

            List<ProductModel> products = new List<ProductModel>();

            var expectedProduct = new ProductModel
            {
                Title = "title",
                Description = "description",
            };

            products.Add(expectedProduct);

            var mockContext = new Mock<ControllerContext>();
            repo.Setup(x => x.GetAllProducts()).ReturnsAsync(products);

            var controller = new ProductController(repo.Object)
            {
                ControllerContext = mockContext.Object
            };

            // act
            var allProducts = await controller.GetAllProducts();
            var productModels = allProducts.Model as List<ProductModel>;
            var actualProduct = productModels.First();

            // assert
            // assert
            Assert.That(productModels.Count, Is.EqualTo(1));
            Assert.That(actualProduct.Title, Is.EqualTo(expectedProduct.Title));
            Assert.That(actualProduct.Description, Is.EqualTo(expectedProduct.Description));
        }

        [Test()]
        public async Task AddNewProductTest()
        {
            // arrange
            var repo = new Mock<IProductRepository>();

            List<ProductModel> products = new List<ProductModel>();

            var expectedProduct = new ProductModel
            {
                Title = "title",
                Description = "description",
            };

            products.Add(expectedProduct);

            var mockContext = new Mock<ControllerContext>();
            repo.Setup(x => x.AddNewProduct(expectedProduct)).ReturnsAsync(1);

            var controller = new ProductController(repo.Object)
            {
                ControllerContext = mockContext.Object
            };

            // act
            var result = await controller.AddNewProduct(expectedProduct) as RedirectToActionResult;

            Assert.That(result?.ActionName, Is.EqualTo("AddNewProduct"));
            Assert.That(result?.RouteValues?["isSuccess"], Is.EqualTo(true));
            Assert.That(result?.RouteValues?["productId"], Is.EqualTo(1));
        }

        [Test()]
        public async Task GetProductTest()
        { 
            // arrange
            var repo = new Mock<IProductRepository>();

            var expectedProduct = new ProductModel
            {
                Title = "title",
                Description = "description",
            };
            var mockContext = new Mock<ControllerContext>();
            repo.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(expectedProduct);

            var controller = new ProductController(repo.Object)
            {
                ControllerContext = mockContext.Object
            };
             
            // act
            var result = await controller.GetProduct(1);
            var resultData = result.Model as ProductModel;

            // assert
            Assert.That(expectedProduct.Title, Is.EqualTo(resultData.Title));
            Assert.That(expectedProduct.Description, Is.EqualTo(resultData.Description));
        }
    }
}