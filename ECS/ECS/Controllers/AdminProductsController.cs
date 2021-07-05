using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECS.Controllers
{
    public class AdminProductsController : Controller
    {
        ECSEntities context = new ECSEntities();

        // GET: AdminProducts
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            var categories = context.Categories.ToList();
            List<ProductCategoryName> productCategoryNames = new List<ProductCategoryName>();
            
            foreach(var item in products)
            {
                ProductCategoryName productCategoryName = new ProductCategoryName();
                Product product = new Product();
                productCategoryName.Product = item;
                foreach(var cat in categories)
                {
                    
                    if(item.CategoryId == cat.Id)
                    {
                        productCategoryName.CategoryName = cat.Name;
                    }
                }
                productCategoryNames.Add(productCategoryName);
            }

            return View(productCategoryNames);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            Product product = new Product();
            ProductCategory pc = new ProductCategory();
            pc.Categories = context.Categories.ToList();
            return View(pc);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory p)
        {
            Product pp = new Product();
            pp = p.Product;
            context.Products.Add(pp);
            context.SaveChanges();
            return RedirectToAction("Index","AdminProducts");
        }
    }
}