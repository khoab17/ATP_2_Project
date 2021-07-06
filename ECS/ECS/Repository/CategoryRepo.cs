using ECS.Models;
using ECS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.Repository
{
    
    public class CategoryRepo
    {
        ECSEntities context = new ECSEntities();
        public List<DefaultViewModel> NumberOfProductsInCategory()
        {
            var list = context.Database.SqlQuery<DefaultViewModel>("Select Categories.Name as name , Count(Products.CategoryId) as DefaultCount from Categories, Products where Categories.Id = Products.CategoryId and Categories.Id in ( select CategoryId from Products group by CategoryId) group by Categories.Name");

            List<DefaultViewModel> info = new List<DefaultViewModel>();

            foreach (DefaultViewModel data in list)
            {
                // info.Name = data.Name;
                //info.DefaultCount = data.DefaultCount;/
                info.Add(data);
            }

            return info;
        }
    }
}