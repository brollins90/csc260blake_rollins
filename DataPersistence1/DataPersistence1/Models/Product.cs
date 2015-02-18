using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataPersistence1.Models
{
    [Serializable]
    public class Product
    {
        private static int nextId = 1;
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You need to enter a description")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Range(.01f, float.MaxValue, ErrorMessage = "Minimum cost is .01")]
        public decimal Cost { get; set; }

        public Product()
        {
            Id = nextId++;
        }

        public void UpdateProduct(Product newProduct)
        {
            this.Description = newProduct.Description;
            this.Name = newProduct.Name;
            this.Cost = newProduct.Cost;
        }
    }
}