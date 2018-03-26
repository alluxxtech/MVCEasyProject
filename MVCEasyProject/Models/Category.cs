using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEasyProject.Models
{
    public class Category
    {
        [Key]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter new category")]       
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}