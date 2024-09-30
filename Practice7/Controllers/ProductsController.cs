using DataAccess.Data;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Practice7.Controllers
{
    public class ProductsController : ControllerBase
    {
       
            private readonly ApplicationDbContext db;

            public ProductsController(ApplicationDbContext db)
            {
                this.db = db;
            }

            [HttpGet]
           // [RequiredClaim("read", "true")]
            public IActionResult GetProduct()
            {
                return Ok(db.Products.ToList());
            }

            [HttpGet("{id}")]
           // [RequiredClaim("read", "true")]
            public IActionResult GetProductById(int id)
            {
                return Ok(HttpContext.Items["Product"]);
            }

            [HttpPost]
        [TypeFilter(typeof(Products_ValidateCreateProductFilterAttribute))]
        // [RequiredClaim("write", "true")]
        public IActionResult CreateProduct([FromBody] Products product)
        {
                this.db.Products.Add(product);
                this.db.SaveChanges();

                return CreatedAtAction(nameof(GetProductById),
                    new { id = product.Id },
                    product);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Products_ValidateCreateProductFilterAttribute))]
        // [Shirt_ValidateUpdateShirtFilter]
        // [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        //[RequiredClaim("write", "true")]
        public IActionResult UpdateProduct(int id, Products product)
            {
                var productToUpdate = HttpContext.Items["product"] as Products;
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;

                db.SaveChanges();

                return NoContent();
            }

            [HttpDelete("{id}")]
        [TypeFilter(typeof(Product_ValidateProductIdFilterAttribute))]
        //[RequiredClaim("delete", "true")]
        public IActionResult DeleteProduct(int id)
        {
                var productToDelete = HttpContext.Items["product"] as Products;

                db.Products.Remove(productToDelete);
                db.SaveChanges();

                return Ok(productToDelete);
        }
    }
}
