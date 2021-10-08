using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Model;
using ProductAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<tblCategory>> Get()
        {


            return _categoryService.Get();
        }



        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        public ActionResult<tblCategory> Get(string id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult<tblCategory> Create(tblCategory category)
        {
            _categoryService.Create(category);

            return CreatedAtRoute("GetCategory", new { id = category.Id.ToString() }, category);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, tblCategory categoryIn)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Update(id, categoryIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Remove(category.Id);

            return NoContent();
        }
    }
}
