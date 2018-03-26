using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEasyProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter new product name12")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter product company1")]
        public string Company { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}