using _08PC_MVCCodeFirst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _08PC_MVCCodeFirst.Entities;

namespace _08PC_MVCCodeFirst.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly MVCContext context = new MVCContext();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            value.CategoryColor = category.CategoryColor;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}