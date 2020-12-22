using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)] // this property will be used for quantity that are less than 50
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]  // this property will be used for quantity that are bewtween 50 and 99
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]  // this property will be used for quantity that are more than 100
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int CoatingTypeId { get; set; }

        [ForeignKey("CoatingTypeId")]
        public CoatingType CoatingType { get; set; }
    }
}
