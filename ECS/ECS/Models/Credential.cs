using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class Credential
    {
        
        [Key,ForeignKey("User")]
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}