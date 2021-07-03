using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ECSEntities context = new ECSEntities();

        public ActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserCredential userCredential)
        {
            //context.Users.Add(admin);
            //context.SaveChanges();
            userCredential.User.RegDate = DateTime.Now;
            context.Users.Add(userCredential.User);
            context.SaveChanges();
            User user=context.Users.Where(x => x.Email == userCredential.User.Email).FirstOrDefault();
            userCredential.Credential.UserId = user.Id;
            userCredential.Credential.UserType = "Admin";
            context.Credentials.Add(userCredential.Credential);
            context.SaveChanges();
            
            return RedirectToAction("Index","Admin");
        }
    }
}