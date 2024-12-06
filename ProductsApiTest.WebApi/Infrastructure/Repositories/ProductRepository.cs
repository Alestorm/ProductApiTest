using Microsoft.Data.SqlClient;
using ProductsApiTest.WebApi.Domain.Contracts;
using ProductsApiTest.WebApi.Domain.Entities;
using ProductsApiTest.WebApi.Infrastructure.EFCoreConfiguration;

namespace ProductsApiTest.WebApi.Infrastructure.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            
        }
        public Result<Product> AddProduct(Product product)
        {
            try
            {
                if (_context.Products.Any(p => p.Name.Equals(product.Name)))
                {
                    return Result<Product>.Failure(409, "Conflict");
                }
                _context.Products.Add(product);
                _context.SaveChanges();

                return Result<Product>.Success(201, product);
            }
            catch (Exception ex)
            {
                return Result<Product>.Failure(500, ex.Message);
            }
        }

        public Result<int> DeleteProduct(int idProduct)
        {
            try
            {
                Product product = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct);
                if (product == null)
                {
                    return Result<int>.Failure(404, "Product not found");
                }
                int id = product.IdProduct;
                _context.Products.Remove(product);
                _context.SaveChanges();

                

                return Result<int>.Success(200, id);

            }
            catch (Exception ex)
            {
                return Result<int>.Failure(500, ex.Message);
            }
        }

        public Result<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> products = _context.Products.ToList();
                return Result<List<Product>>.Success(200, products);
            }
            catch (Exception ex)
            {
                return Result<List<Product>>.Failure(500, ex.Message);
            }
        }

        public Result<Product> GetProductById(int idProduct)
        {
            try
            {
                Product product = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct);
                if (product == null)
                {
                    return Result<Product>.Failure(404, "Product not found");
                }
                return Result<Product>.Success(200, product);
            }
            catch (Exception ex)
            {
                return Result<Product>.Failure(500, ex.Message);
            }
        }

        public Result<Product> UpdateProduct(Product product)
        {
            try
            {
                Product updateProduct = _context.Products.FirstOrDefault(p => p.IdProduct == product.IdProduct);
                if (updateProduct == null)
                {
                    return Result<Product>.Failure(404, "Product not found");
                }
                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.Price = product.Price;

                _context.SaveChanges();

                return Result<Product>.Success(200, updateProduct);

            }
            catch (Exception ex)
            {
                return Result<Product>.Failure(500, ex.Message);
            }
        }
    }
}
