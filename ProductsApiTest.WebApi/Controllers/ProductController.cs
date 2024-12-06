using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ProductsApiTest.WebApi.Application.Services;
using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Status == 400)
            {
                return BadRequest(result.ErrorMessage);
            }
            if (result.Status == 409)
            {
                return Conflict(result.ErrorMessage);
            }
            return Created("", result.Value);
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (!result.IsSucess)
            {
                return StatusCode(result.Status, result.ErrorMessage);
            }
            return Ok(result.Value);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var result = _productService.GetProductById(id);
            if (result.Status == 404)
            {
                return NotFound(result.ErrorMessage);
            }
            if (result.Status == 400)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Value);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result.Status == 404)
            {
                return NotFound(result.ErrorMessage);
            }
            if (result.Status == 400)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Value);
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var result = _productService.UpdateProduct(product);
            if (result.Status == 400)
            {
                return BadRequest(result.ErrorMessage);
            }
            if (result.Status == 404)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(result.Value);
        }

    }
}
