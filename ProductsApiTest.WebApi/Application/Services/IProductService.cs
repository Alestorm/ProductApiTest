using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Application.Services
{
    public interface IProductService
    {
        Result<Product> AddProduct(Product product);
        Result<Product> GetProductById(int idProduct);
        Result<List<Product>> GetAllProducts();
        Result<Product> UpdateProduct(Product product);
        Result<int> DeleteProduct(int idProduct);
    }
}
