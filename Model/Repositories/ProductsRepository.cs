using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public static class ProductsRepository
    {
        private static List<Products> productsList = new List<Products>()
        {
               new Products { Id = 101, Name = "Totis", Price = 15 },
               new Products { Id = 102, Name = "Cheetos", Price = 23 },
               new Products { Id = 103, Name = "Doritos", Price = 20 },
               new Products { Id = 104, Name = "Sabritones", Price = 30 },
               new Products { Id = 105, Name = "Arizona", Price = 14 },
               new Products { Id = 106, Name = "Chokis", Price = 20 },
               new Products { Id = 107, Name = "Emperador", Price = 21 },
               new Products { Id = 108, Name = "Boing", Price = 16 },
               new Products { Id = 109, Name = "Takis", Price = 19 },
               new Products { Id = 110, Name = "Oreo", Price = 25 }
        };
        public static List<Products> GetProducts()
        {
            return productsList;
        }

        public static bool ProductExists(int id)
        {
            return productsList.Any(x => x.Id == id);
        }

        public static Products? GetProductById(int id)
        {
            return productsList.FirstOrDefault(x => x.Id == id);
        }

        
        public static void AddProduct(Products product)
        {
            int maxId = productsList.Max(x => x.Id);
            product.Id = maxId + 1;

            productsList.Add(product);
        }

        public static void UpdateProduct(Products product)
        {
            var productToUpdate = productsList.First(x => x.Id == product.Id);
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
        }

        public static void DeleteProduct(int Id)
        {
            var product = GetProductById(Id);
            if (productsList != null)
            {
                productsList.Remove(product);
            }
        }
    }
}
