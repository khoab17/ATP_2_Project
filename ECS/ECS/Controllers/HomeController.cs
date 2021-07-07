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
    public class HomeController : Controller
    {
        ECSEntities context = new ECSEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            var categories = context.Categories.ToList();
            List<ProductCategoryName> productCategoryNames = new List<ProductCategoryName>();

            foreach (var item in products)
            {
                ProductCategoryName productCategoryName = new ProductCategoryName();
                Product product = new Product();
                productCategoryName.Product = item;
                foreach (var cat in categories)
                {

                    if (item.CategoryId == cat.Id)
                    {
                        productCategoryName.CategoryName = cat.Name;
                    }
                }
                productCategoryNames.Add(productCategoryName);
            }

            return View(productCategoryNames);
        }


        //===========AddToCart===================Product================================
        [Authorize(Roles = "Buyer")]
        public ActionResult AddToCart(int Id)
        {
            if (Session["Cart"] == null)
            {
                List<OrderDetails> cart = new List<OrderDetails>();
                cart.Add(new OrderDetails(context.Products.Find(Id),1));
                Session["Cart"] = cart;
            }
            else
            {
                List<OrderDetails> cart = (List<OrderDetails>)Session["Cart"];
                int index = AlreadyAdded(Id);
                if (index == -1)
                    cart.Add(new OrderDetails(context.Products.Find(Id),1));
                else
                    cart[index].Quantity++;
                Session["Cart"] = cart;

            }
            return View("Cart");
        }

        public ActionResult Remove(int id)
        {
            int index = AlreadyAdded(id);
            List<OrderDetails> cart = (List<OrderDetails>)Session["Cart"];
            cart.RemoveAt(index);

            Session["Cart"] = cart;
            return View("Cart");

        }
        private int AlreadyAdded(int id)
        {
            List<OrderDetails> cart = (List<OrderDetails>)Session["Cart"];
            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Product.Id == id)

                    return i;

            return -1;

        }

        //=============================================================

        [Authorize(Roles = "Buyer")]
        public ActionResult Cart()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Cart(OrderDetails orderDetails)
        {
            return View();
        }

        //====================================================Profile For Buyer And Sellers

        [Authorize(Roles = "Buyer")]
        public ActionResult Profile()
        {
            int Id = Convert.ToInt32( Session["UserId"]);
            //User user = new User();
            User user = context.Users.Find(Id);
            return View(user);
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
                return RedirectToAction("Profile", "Home");
            }
            else
                return View();
        }


    }
}