using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Domain.Contracts
{
    public interface IProduct
    {
        Result<Product> AddProduct(Product product);
        Result<Product> GetProductById(int idProduct);
        Result<List<Product>> GetAllProducts();
        Result<Product> UpdateProduct(Product product);
        Result<int> DeleteProduct(int idProduct);
    }
}
