using DataAccess.Data;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Practice7.Controllers
{
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SalesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetSale()
        {
            return Ok(db.Sales.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            return Ok(HttpContext.Items["Sale"]);
        }

        [HttpPost]
        public IActionResult CreateSale([FromBody] Sales sale)
        {
            this.db.Sales.Add(sale);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(GetSaleById),
                new { id = sale.SaleId },
                sale);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, Sales sale)
        {
            var saleToUpdate = HttpContext.Items["sale"] as Sales;
            saleToUpdate.Name = sale.Name;
            saleToUpdate.Quantity = sale.Quantity;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var saleToDelete = HttpContext.Items["sale"] as Sales;

            db.Sales.Remove(saleToDelete);
            db.SaveChanges();

            return Ok(saleToDelete);
        }
    }
}
