using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
        public static Home Window { get; set; }

        public void Start()
        {
            // Initialize the product list with example products
            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Foto 10x15",
                Price = 2.55m,
                Description = "Standard 10x15 photo print"
            });
            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Foto 20x30",
                Price = 5.00m,
                Description = "Large 20x30 photo print"
            });

            // Set the initial shop price list
            ShopManager.SetShopPriceList("Prijzen:\n€2,50\n€5,00");

            // Loop through the products and add them to the price list
            foreach (KioskProduct product in ShopManager.Products)
            {
                string priceListEntry = $"{product.Name}: {product.Description} - {product.Price:C}";
                ShopManager.AddShopPriceList(priceListEntry);
            }

            // For demonstration purposes, display the price list
            var priceList = ShopManager.GetShopPriceList();
            foreach (var entry in priceList)
            {
                Console.WriteLine(entry);
            }

            // Set the receipt text (assuming this is part of the UI update)
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Update the dropdown with products
            ShopManager.UpdateDropDownProducts();
        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            // Implementation for adding a product (if needed)
        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {
            // Implementation for resetting the product list (if needed)
        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
            // Implementation for saving changes (if needed)
        }
    }
}