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
                User user=context.Users.Where(x => x.Email == credential.Email).FirstOrDefault();
                if(user!=null)
                {
                    Credential cred = context.Credentials.Where(m => m.UserId == user.Id).FirstOrDefault();
                    //var users=context.Users.ToList();

                        if(cred.Password==credential.Password)
                        {
                        //string name = user.Id.ToString();
                        Session["UserId"] = cred.UserId;
                            FormsAuthentication.SetAuthCookie(user.Name, false);
                            if(cred.UserType=="Admin")
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                           
                        }
                        else
                        {
                        ModelState.AddModelError("Invalid", "Incorrect Password");
                        return View(credential);
                    }    
                }
                else
                {
                    ModelState.AddModelError("Invalid", "Invalid Email or Password");
                    return View(credential);
                }
            }
            return View(credential);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = null;
            return RedirectToAction("Login", "Authorization");
        }
    }
}