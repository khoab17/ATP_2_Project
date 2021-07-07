using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public  int  ProductId { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public Product Product { get; set; }
        public Order Orders { get; set; }

    }
}