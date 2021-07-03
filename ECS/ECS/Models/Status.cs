using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>(); 
        }
        public int Id { get; set; }
        public string  Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}