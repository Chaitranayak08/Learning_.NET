using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_DotNet.Models
{
         public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description {  get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author {  get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public double ListPrice {  get; set; }

         
        //For 1 to 50 units of products
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }


        //For 50+ units of products
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }


        //For 100+ units of products
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }


     
        public int CategoryId { get; set; }
      
        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Category Category { get; set; }   //navigation property for category table(foreign key)

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
