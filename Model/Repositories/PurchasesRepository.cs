using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public static class PurchasesRepository
    {
        private static List<Purchases> purchasesList = new List<Purchases>()
        {
               new Purchases { PurchaseId = 301, Name = "Arizona", Quantity = 400 },
               new Purchases { PurchaseId = 302, Name = "Cheetos", Quantity = 500 },
               new Purchases { PurchaseId = 303, Name = "Sabritones", Quantity = 200 },
               new Purchases { PurchaseId = 304, Name = "Boing", Quantity = 400 },
               new Purchases { PurchaseId = 305, Name = "Chokis", Quantity = 300 },
               new Purchases { PurchaseId = 306, Name = "Sabritones", Quantity = 500 },
               new Purchases { PurchaseId = 307, Name = "Chokis", Quantity = 450 },
               new Purchases { PurchaseId = 308, Name = "Totis", Quantity = 300 },
               new Purchases { PurchaseId = 309, Name = "Cheetos", Quantity = 250 },
               new Purchases { PurchaseId = 310, Name = "Totis", Quantity = 350 }
        };
        public static List<Purchases> GetPurchases()
        {
            return purchasesList;
        }

        public static bool PurchaseExists(int id)
        {
            return purchasesList.Any(x => x.PurchaseId == id);
        }

        public static Purchases? GetPurchaseById(int id)
        {
            return purchasesList.FirstOrDefault(x => x.PurchaseId == id);
        }


        public static void AddPurchase(Purchases purchase)
        {
            int maxId = purchasesList.Max(x => x.PurchaseId);
            purchase.PurchaseId = maxId + 1;

            purchasesList.Add(purchase);
        }

        public static void UpdatePurchase(Purchases purchase)
        {
            var purchaseToUpdate = purchasesList.First(x => x.PurchaseId == purchase.PurchaseId);
            purchaseToUpdate.Name = purchase.Name;
            purchaseToUpdate.Quantity = purchase.Quantity;
        }

        public static void DeletePurchase(int Id)
        {
            var purchase = GetPurchaseById(Id);
            if (purchasesList != null)
            {
                purchasesList.Remove(purchase);
            }
        }
    }
}
