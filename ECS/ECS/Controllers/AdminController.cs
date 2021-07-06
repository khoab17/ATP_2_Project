using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            //context.Users.Where(x=>x.Id)
            //var admin=context.Credentials.Where(x => x.UserType == "Admin").FirstOrDefault();
            // var users = context.Users.Where(x => x.Id == admin.UserId).FirstOrDefault();

            var admin = context.Credentials.ToList();
            var user = context.Users.ToList();
            List<Credential> admins=new List<Credential>();
            List<User> users = new List<User>();
            foreach (var item in admin)
            {
                if (item.UserType == "Admin")
                {
                    foreach(var i in user)
                    {
                        if(i.Id==item.UserId)
                        {
                            users.Add(i);
                        }
                    }
                }
            }
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
            if (ModelState.IsValid)
            {
                userCredential.User.RegDate = DateTime.Now;
                context.Users.Add(userCredential.User);
                context.SaveChanges();
                User user = context.Users.Where(x => x.Email == userCredential.User.Email).FirstOrDefault();
                userCredential.Credential.UserId = user.Id;
                userCredential.Credential.UserType = "Admin";
                context.Credentials.Add(userCredential.Credential);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
                return View();
        }

        public ActionResult Edit(int Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
                return View();         
        }

        public ActionResult Delete(int Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            context.Users.Attach(user);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


    }
}