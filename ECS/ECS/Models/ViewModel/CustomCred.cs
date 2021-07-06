using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECS.Models.ViewModel
{
    public class CustomCred
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}