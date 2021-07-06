using ECS.Models;
using ECS.Models.ViewModel;
using ECS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECS.Controllers
{
    [Authorize(Roles ="Admin")]
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
            //Category category = new Category();
            //Product product = new Product();
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

        public ActionResult Edit(int Id)
        {
            ProductCategory productCategory= new ProductCategory();
            Product product = context.Products.Where(x => x.Id == Id).FirstOrDefault();
            productCategory.Product = product;
            productCategory.Categories = context.Categories.ToList();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory p)
        {
            if (ModelState.IsValid)
            {
                context.Products.AddOrUpdate(p.Product);
                context.SaveChanges();
                return RedirectToAction("Index", "AdminProducts");
            }
            else
                return View(p);
        }

        public ActionResult Delete(int Id)
        {
            Product product = context.Products.Where(x => x.Id == Id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            Product p = context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            context.Products.Attach(p);
            context.Products.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index", "AdminProducts");
        }

        public ActionResult CreateCategory()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index", "AdminProducts");
            }
            else
                return View(category);
        }


        //================================datavisu==========================================
        public ActionResult CategoryProductAmountChart()
        {
            CategoryRepo category = new CategoryRepo();
            var list = category.NumberOfProductsInCategory();

            List<BarChartModel> categoriesProductAmount = new List<BarChartModel>();

            foreach (var data in list)
            {
                BarChartModel chart = new BarChartModel(data.Name, (double)data.DefaultCount);
                categoriesProductAmount.Add(chart);
            }

            ViewBag.DataPoints = Newtonsoft.Json.JsonConvert.SerializeObject(categoriesProductAmount);
            return View();
        }

    }
}