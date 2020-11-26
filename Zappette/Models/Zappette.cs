using System;
using System.Collections.Generic;
using System.Text;
using EntrepotService;
using ScanningTool.Interfaces;

namespace ScanningTool.Models
{
    class Zappette : IScanningTool
    {
        public EntrepotClient entrepot { get; set; }
        public void Scan(EntrepotService.Product product)
        {
            entrepot.Products2Async(product.Id);
            Console.WriteLine("------");
            Console.WriteLine("Produit: " + product.Name);
            Console.WriteLine("Description: " + product.Description);
            Console.WriteLine("Quantité: " + product.Quantity);
            Console.WriteLine("------");
            //get product quantity in BDD
        }
        public void AddProduct(EntrepotService.Product product)
        {
            //appel méthode addProduct du ms BDD
            Console.WriteLine("Stock +1: " + product.Name);
            entrepot.AddItemAsync(product.Id);
        }
        public void RemoveProduct(EntrepotService.Product product)
        {
            //appel méthode addProduct du ms BDD
            Console.WriteLine("Stock -1: " + product.Name);
            entrepot.RemoveItemAsync(product.Id);
        }
    }
}
