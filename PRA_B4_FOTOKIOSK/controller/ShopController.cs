using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Shapes;

namespace PRA_B4_FOTOKIOSK.controller
{

    public class ShopController
    {
        public static Home Window { get; set; }
        decimal countNumberOne;


        public void Start()
        {
            // Initialize the product list with example products
            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Regular Photo\n",
                Price = 2.55m,
                Description = "10x15 photo print\n"
            });
            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "\nLarge Photo\n",
                Price = 5.00m,
                Description = "20x30 photo print\n"
            });

            // Set the initial shop price list
            ShopManager.SetShopPriceList("Prijzen:\n€2,55\n€5,00\n\n");

            // Loop through the products and add them to the price list
            foreach (KioskProduct product in ShopManager.Products)
            {
                string priceListEntry = $"{product.Name}: {product.Description} - {product.Price:C}";
                ShopManager.AddShopPriceList(priceListEntry);
            }

            // For demonstration purposes, display the price list

            //var priceList = ShopManager.GetShopPriceList();
            //foreach (var entry in priceList)
            //{
            //    Console.WriteLine(entry);
            //}

            // Set the receipt text (assuming this is part of the UI update)
            ShopManager.SetShopReceipt("Bonnetje:\n");

            // Update the dropdown with products
            ShopManager.UpdateDropDownProducts();
        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            var selectedProduct = ShopManager.GetSelectedProduct();
            var photoID = ShopManager.GetFotoId();
            var amount = ShopManager.GetAmount();

            ShopManager.AddShopReceipt($"Foto-ID: {photoID}\n");
            ShopManager.AddShopReceipt($"Product: {selectedProduct.Name}\n");
            ShopManager.AddShopReceipt($"Aantal: {amount}\n");

            // Bereken het totaalbedrag
            decimal totalPrice = selectedProduct.Price * amount.Value;




            // Voeg het totaalbedrag toe aan de bon
            ShopManager.AddShopReceipt($"Totaal: €{totalPrice}\n");

            // zorg dat de total prijs naar een andere variabele gaat
            countNumberOne += totalPrice;
        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {
        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
            
            string ShopReceipt = ShopManager.GetShopReceipt();

            // Controleer of de geselecteerde product niet null is
            
                string path = @"../../../text.txt";

                string data = countNumberOne.ToString();

                File.WriteAllText(path, $"ShopReceipt: {ShopReceipt}\n");
            

        }
    }
}