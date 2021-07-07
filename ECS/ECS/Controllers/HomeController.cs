using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
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

        [Authorize(Roles ="Buyer")]
        public ActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cart(OrderDetails orderDetails)
        {
            return View();
        }


    }
}