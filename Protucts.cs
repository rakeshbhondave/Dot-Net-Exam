using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class Products
    {  
        [Display(Name ="Product ID")]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Required Field")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }


        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}