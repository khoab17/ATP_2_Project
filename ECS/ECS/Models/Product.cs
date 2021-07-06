﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class Product
    {
        public  int  Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public int Price { get; set; }

        [Required (ErrorMessage="Category required")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}