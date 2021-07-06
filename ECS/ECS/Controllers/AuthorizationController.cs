using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECS.Controllers
{
    public class AuthorizationController : Controller
    {
        ECSEntities context = new ECSEntities();
        // GET: Authorization
        public ActionResult Login()
        {
            CustomCred login = new CustomCred();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(CustomCred credential)
        {
            if(ModelState.IsValid)
            {
                //bool IsValid = context.Credentials.Any(m =>m.UserId == credential.UserId && m.Password == credential.Password).
                //bool IsValid = false;
                Credential cr=context.Credentials.Where(x => x.UserId == credential.UserId && x.Password == credential.Password).FirstOrDefault();
                if(cr!=null)
                {
                    var users=context.Users.ToList();
                    foreach(var item in users)
                    {
                        if(item.Id==credential.UserId)
                        {
                            FormsAuthentication.SetAuthCookie(item.Name, false);
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Invalid id or password");
                    return View(credential);
                }
            }
            return View(credential);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authorization");
        }
    }
}