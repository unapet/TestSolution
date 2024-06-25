using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Repository
{
    public interface IProductRepository
    {
        Task<int> AddNewProduct(ProductModel model);
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
     }
}