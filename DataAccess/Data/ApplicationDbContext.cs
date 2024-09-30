using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding
            modelBuilder.Entity<Products>().HasData(
               new Products { Id = 101, Name = "Totis", Price = 15 },
               new Products { Id = 102, Name = "Cheetos", Price = 23 },
               new Products { Id = 103, Name = "Doritos", Price = 20 },
               new Products { Id = 104, Name = "Sabritones", Price = 30 },
               new Products { Id = 105, Name = "Arizona", Price = 14 },
               new Products { Id = 106, Name = "Chokis", Price = 20 },
               new Products { Id = 107, Name = "Emperador", Price = 21 },
               new Products { Id = 108, Name = "Boing", Price = 16 },
               new Products { Id = 109, Name = "Takis", Price = 19 },
               new Products { Id = 110, Name = "Oreo", Price = 25 });


            modelBuilder.Entity<Sales>().HasData(
                new Sales { SaleId = 201, Name = "Boing", Quantity = 100 },
                new Sales { SaleId = 202, Name = "Oreo", Quantity = 230 },
                new Sales { SaleId = 203, Name = "Totis", Quantity = 210 },
                new Sales { SaleId = 204, Name = "Arizona", Quantity = 140 },
                new Sales { SaleId = 205, Name = "Oreo", Quantity = 180 },
                new Sales { SaleId = 206, Name = "Arizona", Quantity = 258 },
                new Sales { SaleId = 207, Name = "Totis", Quantity = 305 },
                new Sales { SaleId = 208, Name = "Boing", Quantity = 179 },
                new Sales { SaleId = 209, Name = "Totis", Quantity = 250 },
                new Sales { SaleId = 210, Name = "Cheetos", Quantity = 289 });


            modelBuilder.Entity<Purchases>().HasData(
               new Purchases { PurchaseId = 301, Name = "Arizona", Quantity = 400 },
               new Purchases { PurchaseId = 302, Name = "Cheetos", Quantity = 500 },
               new Purchases { PurchaseId = 303, Name = "Sabritones", Quantity = 200 },
               new Purchases { PurchaseId = 304, Name = "Boing", Quantity = 400 },
               new Purchases { PurchaseId = 305, Name = "Chokis", Quantity = 300 },
               new Purchases { PurchaseId = 306, Name = "Sabritones", Quantity = 500 },
               new Purchases { PurchaseId = 307, Name = "Chokis", Quantity = 450 },
               new Purchases { PurchaseId = 308, Name = "Totis", Quantity = 300 },
               new Purchases { PurchaseId = 309, Name = "Cheetos", Quantity = 250 },
               new Purchases { PurchaseId = 310, Name = "Totis", Quantity = 350 });


            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 101, Name = "Totis", Price = 15, Quantity = 900 },
                new Inventory { Id = 102, Name = "Cheetos", Price = 23, Quantity = 800 },
                new Inventory { Id = 103, Name = "Doritos", Price = 20, Quantity = 860 },
                new Inventory { Id = 104, Name = "Sabritones", Price = 30, Quantity = 970 },
                new Inventory { Id = 105, Name = "Arizona", Price = 14, Quantity = 750 },
                new Inventory { Id = 106, Name = "Chokis", Price = 20, Quantity = 870 },
                new Inventory { Id = 107, Name = "Emperador", Price = 21, Quantity = 790 },
                new Inventory { Id = 108, Name = "Boing", Price = 16, Quantity = 940 },
                new Inventory { Id = 109, Name = "Takis", Price = 19, Quantity = 780 },
                new Inventory { Id = 110, Name = "Oreo", Price = 25, Quantity = 890 });
        }
    }
}
