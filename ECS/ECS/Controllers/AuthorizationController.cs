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
                        if (cred.UserType == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (cred.UserType == "Buyer")
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        else if (cred.UserType == "Seller")
                        {
                            return RedirectToAction("Index", "Buyer");
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
    //=========================Registraion Panel===================================
        public ActionResult Registration()
        {
            UserCredential userCredential = new UserCredential();
            return View(userCredential);
        }
        [HttpPost]
        public ActionResult Registration(UserCredential userCredential)
        {
            if(ModelState.IsValid)
            {
                userCredential.User.RegDate = DateTime.Now;
                context.Users.Add(userCredential.User);
                context.SaveChanges();
                User user = context.Users.Where(x => x.Email == userCredential.User.Email).FirstOrDefault();
                userCredential.Credential.UserId = user.Id;
                //userCredential.Credential.UserType = "Admin";
                context.Credentials.Add(userCredential.Credential);
                context.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(userCredential);
            }
            
        }
        //===========================================================

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = null;
            return RedirectToAction("Login", "Authorization");
        }
    }
}