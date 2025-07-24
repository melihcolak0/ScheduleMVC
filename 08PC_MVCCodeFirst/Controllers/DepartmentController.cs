using _08PC_MVCCodeFirst.Context;
using _08PC_MVCCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _08PC_MVCCodeFirst.Controllers
{
    public class DepartmentController : Controller
    {
        MVCContext context = new MVCContext();

        public ActionResult DepartmentList()
        {
            var values = context.Departments.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var value = context.Departments.Find(id);
            context.Departments.Remove(value);
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var value = context.Departments.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            var value = context.Departments.Find(department.DepartmentId);
            value.DepartmentName = department.DepartmentName;           
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
    }
}
