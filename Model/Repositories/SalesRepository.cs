using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public static class SalesRepository
    {
        private static List<Sales> SalesList = new List<Sales>()
        {
                new Sales { SaleId = 201, Name = "Boing", Quantity = 100 },
                new Sales { SaleId = 202, Name = "Oreo", Quantity = 230 },
                new Sales { SaleId = 203, Name = "Totis", Quantity = 210 },
                new Sales { SaleId = 204, Name = "Arizona", Quantity = 140 },
                new Sales { SaleId = 205, Name = "Oreo", Quantity = 180 },
                new Sales { SaleId = 206, Name = "Arizona", Quantity = 258 },
                new Sales { SaleId = 207, Name = "Totis", Quantity = 305 },
                new Sales { SaleId = 208, Name = "Boing", Quantity = 179 },
                new Sales { SaleId = 209, Name = "Totis", Quantity = 250 },
                new Sales { SaleId = 210, Name = "Cheetos", Quantity = 289 }
    };

        public static List<Sales> GetSale()
        {
            return SalesList;
        }

        public static bool SaleExists(int id)
        {
            return SalesList.Any(x => x.SaleId == id);
        }

        public static Sales? GetSaleById(int id)
        {
            return SalesList.FirstOrDefault(x => x.SaleId == id);
        }

        

        public static void AddSale(Sales sale)
        {
            int maxId = SalesList.Max(x => x.SaleId);
            sale.SaleId = maxId + 1;

            SalesList.Add(sale);
        }

        public static void UpdateSale(Sales sale)
        {
            var saleToUpdate = SalesList.First(x => x.SaleId == sale.SaleId);
            saleToUpdate.Name = sale.Name;
            saleToUpdate.Quantity = sale.Quantity;
        }

        public static void DeleteSales(int Id)
        {
            var sale = GetSaleById(Id);
            if (SalesList != null)
            {
                SalesList.Remove(sale);
            }
        }
    }
}
