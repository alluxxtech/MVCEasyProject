using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEasyProject.Models
{
    public class CategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }        
        [Display(Name = "CategoryName")]
        [Required(ErrorMessage = "Need enter category name")]
        public string Name { get; set; }
    }
    public class CreateCategoryViewModel
    {
        [Display(Name = "CategoryName")]
        [Required(ErrorMessage = "Enter category name")]
        public string Name { get; set; }
    }
    public class EditCategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "New Category Name")]
        [Required(ErrorMessage = "Enter category name")]
        public string Name { get; set; }
    }
    public class DetailsCategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Category Name")]        
        public string Name { get; set; }
    }
    public class DeleteCategoryViewModel
    {
        public int Id { get; set; }
    }



}