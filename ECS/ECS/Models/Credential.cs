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
        

        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserType { get; set; }
  
        public int UserId { get; set; }

    }
}