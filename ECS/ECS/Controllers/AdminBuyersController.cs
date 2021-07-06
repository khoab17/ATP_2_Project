using ECS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECS.Controllers
{
    [Authorize]
    public class AdminBuyersController : Controller
    {
        ECSEntities context = new ECSEntities();
        // GET: AdminBuyers
        public ActionResult Index()
        {
            var buyer = context.Credentials.ToList();
            var user = context.Users.ToList();
            //List<Credential> buyers = new List<Credential>();
            List<User> users = new List<User>();
            foreach (var item in buyer)
            {
                if (item.UserType == "Buyer")
                {
                    foreach (var i in user)
                    {
                        if (i.Id == item.UserId)
                        {
                            users.Add(i);
                        }
                    }
                }
            }
            return View(users);
        }

        public ActionResult Edit(int Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            context.Users.AddOrUpdate(user);
            context.SaveChanges();
            return RedirectToAction("Index", "AdminBuyers");
        }

        public ActionResult Delete(int Id)
        {
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var u = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            var cred = context.Credentials.ToList();
            foreach (var item in cred)
            {
                if (item.UserId == u.Id)
                {
                    item.UserType = "Buyer_D";
                    context.Credentials.AddOrUpdate(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "AdminBuyers");
        }

    }
}