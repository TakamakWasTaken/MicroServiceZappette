using System;
using System.Collections.Generic;
using System.Text;

namespace ScanningTool.Models
{
    class Product
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public Product(string type, string name, string description, string pic)
        {
            Type = type;
            Name = name;
            Description = description;
            Picture = pic;
        }

        public static implicit operator EntrepotService.Product(Product product)
        {
            EntrepotService.Product productEntrepot = new EntrepotService.Product();
            productEntrepot.Picture = product.Picture;
            productEntrepot.Id = product.Id;
            productEntrepot.Name = product.Name;
            productEntrepot.Type = product.Type;
            productEntrepot.Description = product.Description;

            return product;
        }
    }
}
