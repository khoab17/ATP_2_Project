using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models.ViewModel
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Categories = new List<Category>();
        }
        
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}