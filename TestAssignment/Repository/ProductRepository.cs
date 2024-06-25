using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context = null;
        private readonly IConfiguration _configuration;

        public ProductRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewProduct(ProductModel model)
        {
            var newProduct = new Product()
            {
                Title = model.Title,
                Description = model.Description,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Id;

        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _context.Products
                  .Select(product => new ProductModel()
                  {
                      Description = product.Description,
                      Title = product.Title,
                  }).ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id)
                 .Select(product => new ProductModel()
                 {
                     Description = product.Description,
                     Id = product.Id,
                     Title = product.Title,
                 }).FirstOrDefaultAsync();
        }

    }
}
