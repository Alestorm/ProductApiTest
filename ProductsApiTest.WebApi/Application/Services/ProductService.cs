using Azure.Core;
using ProductsApiTest.WebApi.Domain.Contracts;
using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProduct _productRepository;
        public ProductService(IProduct productRepository)
        {
            _productRepository = productRepository;
        }
        public Result<Product> AddProduct(Product product)
        {
            if (product.Name.Equals(""))
            {
                return Result<Product>.Failure(400, "Name required");
            }
            if (product.Price <= 0)
            {
                return Result<Product>.Failure(400, "Price must greater than zero");
            }
            return _productRepository.AddProduct(product);
        }

        public Result<int> DeleteProduct(int idProduct)
        {
            if (idProduct <= 0)
            {
                return Result<int>.Failure(400, "Id must be greater than zero");
            }
            return _productRepository.DeleteProduct(idProduct);
        }

        public Result<List<Product>> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Result<Product> GetProductById(int idProduct)
        {
            if (idProduct <= 0)
            {
                return Result<Product>.Failure(400, "Id must be greater than zero");
            }
            
            return _productRepository.GetProductById(idProduct);
        }

        public Result<Product> UpdateProduct(Product product)
        {
            if (product.Name.Equals(""))
            {
                return Result<Product>.Failure(400, "Name required");
            }
            if (product.Price <= 0)
            {
                return Result<Product>.Failure(400, "Price must greater than zero");
            }

            return _productRepository.UpdateProduct(product);
        }
    }
}
