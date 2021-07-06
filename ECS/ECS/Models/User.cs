using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECS.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required][EmailAddress]
        public string  Email { get; set; }
        [Required][Phone]
        public string Phone { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime RegDate { get; set; }


    }
}