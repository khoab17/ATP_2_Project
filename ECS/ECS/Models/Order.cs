using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public int MyProperty { get; set; }
        public DateTime OrderTime { get; set; }
        public int StatusId { get; set; }

    }
}