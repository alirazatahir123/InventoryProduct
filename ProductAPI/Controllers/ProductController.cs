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
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productyService;
        public ProductController(ProductService productService)
        {
            _productyService = productService;
        }

        [HttpGet]
        public ActionResult<List<tblProduct>> Get() =>
           _productyService.Get();


        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<tblProduct> Get(string id)
        {
            var product = _productyService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult<tblProduct> Create(tblProduct product)
        {
            _productyService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, tblProduct productIn)
        {
            var product = _productyService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productyService.Update(id, productIn);

            return NoContent();
        }
        [HttpDelete("{productid}")]
        public IActionResult Delete(string productid)
        {
            var product = _productyService.Get(productid);

            if (product == null)
            {
                return NotFound();
            }

            _productyService.Remove(product.Id);

            return NoContent();
        }
    }
}
