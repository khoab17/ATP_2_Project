using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Models.ViewModel
{
    public class UserCredential
    {
        public User User { get; set; }
        public Credential Credential { get; set; }
    }
}