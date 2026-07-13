using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {
            var result = _categoryService.Add(category);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = category.CategoryId },
                result
            );
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(
            int id,
            [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest(
                    "URL içindeki id ile CategoryId aynı olmalı."
                );
            }

            var result = _categoryService.Update(category);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}