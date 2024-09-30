using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public static class InventoryRepository
    {
        private static List<Inventory> inventoryList = new List<Inventory>()
        {
                new Inventory { Id = 101, Name = "Totis", Price = 15, Quantity = 900 },
                new Inventory { Id = 102, Name = "Cheetos", Price = 23, Quantity = 800 },
                new Inventory { Id = 103, Name = "Doritos", Price = 20, Quantity = 860 },
                new Inventory { Id = 104, Name = "Sabritones", Price = 30, Quantity = 970 },
                new Inventory { Id = 105, Name = "Arizona", Price = 14, Quantity = 750 },
                new Inventory { Id = 106, Name = "Chokis", Price = 20, Quantity = 870 },
                new Inventory { Id = 107, Name = "Emperador", Price = 21, Quantity = 790 },
                new Inventory { Id = 108, Name = "Boing", Price = 16, Quantity = 940 },
                new Inventory { Id = 109, Name = "Takis", Price = 19, Quantity = 780 },
                new Inventory { Id = 110, Name = "Oreo", Price = 25, Quantity = 890 }
        };
        public static List<Inventory> GetInventory()
        {
            return inventoryList;
        }

        public static bool InventoryProductExists(int id)
        {
            return inventoryList.Any(x => x.Id == id);
        }

        public static Inventory? GetInventoryProductById(int id)
        {
            return inventoryList.FirstOrDefault(x => x.Id == id);
        }


        public static void AddInventoryProduct(Inventory inventory)
        {
            int maxId = inventoryList.Max(x => x.Id);
            inventory.Id = maxId + 1;

            inventoryList.Add(inventory);
        }

        public static void UpdateInventoryProduct(Inventory product)
        {
            var inventoryproductToUpdate = inventoryList.First(x => x.Id == product.Id);
            inventoryproductToUpdate.Name = product.Name;
            inventoryproductToUpdate.Price = product.Price;
        }

        public static void DeleteInventoryProduct(int Id)
        {
            var inventoryproduct = GetInventoryProductById(Id);
            if (inventoryList != null)
            {
                inventoryList.Remove(inventoryproduct);
            }
        }
    }
}
