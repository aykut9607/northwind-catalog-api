using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("details")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("by-category/{categoryId:int}")]
        public IActionResult GetAllByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategory(categoryId);

            return Ok(result);
        }

        [HttpGet("by-price")]
        public IActionResult GetByUnitPrice(
            decimal min,
            decimal max)
        {
            var result = _productService.GetByUnitPrice(min, max);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var result = _productService.Add(product);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.ProductId },
                result
            );
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(
            int id,
            [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(
                    "URL içindeki id ile ProductId aynı olmalı."
                );
            }

            var result = _productService.Update(product);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(
                new Product { ProductId = id }
            );

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}