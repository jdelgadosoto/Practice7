using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Practice7.Controllers
{
    public class PurchasesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public PurchasesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPurchase()
        {
            return Ok(db.Purchases.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            return Ok(HttpContext.Items["Purchase"]);
        }

        [HttpPost]
        public IActionResult CreatePurchase([FromBody] Purchases purchase)
        {
            this.db.Purchases.Add(purchase);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(GetPurchaseById),
                new { id = purchase.PurchaseId },
                purchase);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePurchase(int id, Purchases purchase)
        {
            var purchaseToUpdate = HttpContext.Items["purchase"] as Purchases;
            purchaseToUpdate.Name = purchase.Name;
            purchaseToUpdate.Quantity = purchase.Quantity;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePurchase(int id)
        {
            var purchaseToDelete = HttpContext.Items["purchase"] as Purchases;

            db.Purchases.Remove(purchaseToDelete);
            db.SaveChanges();

            return Ok(purchaseToDelete);
        }
    }
}
