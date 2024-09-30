using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Model.Models;
using Filters;

namespace Practice7.Controllers
{
    public class InventoriesController : ControllerBase
    {

        private readonly ApplicationDbContext db;

        public InventoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetInventoryProduct()
        {
            return Ok(db.Inventory.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetInventoryProductById(int id)
        {
            return Ok(HttpContext.Items["inventory"]);
        }

        [HttpPost]
        public IActionResult CreateInventoryProduct([FromBody] Inventory inventory)
        {
            this.db.Inventory.Add(inventory);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(GetInventoryProductById),
                new { id = inventory.Id },
                inventory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInventoryProduct(int id, Inventory product)
        {
            var inventoryproductToUpdate = HttpContext.Items["inventory"] as Inventory;
            inventoryproductToUpdate.Name = product.Name;
            inventoryproductToUpdate.Price = product.Price;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryProduct(int id)
        {
            var inventoryproductToDelete = HttpContext.Items["inventory"] as Inventory;

            db.Inventory.Remove(inventoryproductToDelete);
            db.SaveChanges();

            return Ok(inventoryproductToDelete);
        }
    }
}
