using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int OrderId { get; set; }


        public Product Product { get; set; }


        [ForeignKey("OrderId")]
        public Order Orders { get; set; }

    }
}