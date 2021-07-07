using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetailes = new HashSet<OrderDetails>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public int MyProperty { get; set; }
        public DateTime OrderTime { get; set; }

        public string OrderAddress { get; set; }
        public int Amount { get; set; }
        public int StatusId { get; set; }

        public ICollection<OrderDetails> OrderDetailes { get; set; }

    }
}