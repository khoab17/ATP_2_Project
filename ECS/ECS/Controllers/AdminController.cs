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
            context.Users.Add(userCredential.User);
            context.Credentials.Add(userCredential.Credential);
            context.SaveChanges();
            
            return RedirectToAction("Index","Admin");
        }
    }
}