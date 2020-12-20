using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
   public class Category
    {
        [Key]
        public int Key { get; set; }

        [Display(Name="Category Name")]
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }


    }
}
