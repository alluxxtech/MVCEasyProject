using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEasyProject.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string CategoryName { get; set; }
    }

    public class CreateProductViewModel
    {
        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "Enter product name")]
        public string Name { get; set; }
        [Display(Name = "Company")]
        [Required(ErrorMessage = "Enter product company name")]
        public string Company { get; set; }
        [Display(Name = "Description")]
        //[Required(ErrorMessage = "Product decription")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        //[Required(ErrorMessage = "Enter product price")]
        public decimal Price { get; set; }
        [Display(Name = "InStock")]
        //[Required(ErrorMessage = "Enter if product in stock")]
        public bool InStock { get; set; }
        [Display(Name = "Category")]
        //[Required(ErrorMessage = "Choose product category")]
        public int CategoryId { get; set; }
    }
    public class DetailsProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Company Name")]
        public string Company { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Product InStock")]
        public bool InStock { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}