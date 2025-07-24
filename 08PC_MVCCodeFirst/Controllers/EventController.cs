using _08PC_MVCCodeFirst.Context;
using _08PC_MVCCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _08PC_MVCCodeFirst.Controllers
{
    public class EventController : Controller
    {
        private readonly MVCContext context = new MVCContext();

        [HttpGet]
        public ActionResult Index()
        {
            var values = context.Events.Where(e => e.Start != null && e.End != null).ToList();
            return View(values);
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            var categories = context.Categories.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            var events = context.Events.Include(e => e.Category).ToList();

            var eventList = events.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                start = e.Start?.ToString("s"), // ISO 8601 format
                end = e.End?.ToString("s"),
                allDay = e.AllDay,
                backgroundColor = e.Category?.CategoryColor ?? "#3788d8",
                borderColor = e.Category?.CategoryColor ?? "#3788d8",
                categoryId = e.CategoryId
            }).ToList();

            return Json(eventList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetExternalEvents()
        {
            // Tarihi boş olan, yani henüz takvime eklenmemiş etkinlikler
            var events = context.Events
                .Include(e => e.Category)
                .Where(e => e.Start == null)
                .Select(e => new
                {
                    id = e.Id,
                    title = e.Title,
                    backgroundColor = e.Category != null ? e.Category.CategoryColor : "#3788d8",
                    borderColor = e.Category != null ? e.Category.CategoryColor : "#3788d8",
                    categoryId = e.CategoryId
                })
                .ToList();

            return Json(events, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            // Yeni etkinlik eklenirken veya güncellenirken kullanılır
            if (e.Id > 0)
            {
                var existing = context.Events.Find(e.Id);
                if (existing != null)
                {
                    existing.Title = e.Title;
                    existing.Start = e.Start;
                    existing.End = e.End;
                    existing.AllDay = e.AllDay;
                    existing.CategoryId = e.CategoryId;
                }
            }
            else
            {
                context.Events.Add(e);
            }

            context.SaveChanges();
            return Json(new { status = "success", id = e.Id });
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var ev = context.Events.Find(id);
            if (ev != null)
            {
                context.Events.Remove(ev);
                context.SaveChanges();
                return Json(new { status = "deleted" });
            }

            return Json(new { status = "notfound" });
        }

        // ** Önemli: Tarihi sürükleyince güncellemek için kullanılacak metot (FromBody yok) **
        [HttpPost]
        public JsonResult UpdateEvent(int id, DateTime start, DateTime? end)
        {
            var existingEvent = context.Events.FirstOrDefault(e => e.Id == id);

            if (existingEvent != null)
            {
                existingEvent.Start = start;
                existingEvent.End = end;
                context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Event not found." });
        }

        // Yeni etkinlik ekleme, başlangıçta tarih boş olabilir
        [HttpPost]
        public JsonResult CreateEvent(string title, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Json(new { success = false, message = "Başlık boş olamaz." });

            var newEvent = new Event
            {
                Title = title,
                Start = null,
                End = null,
                AllDay = true,
                CategoryId = categoryId
            };

            context.Events.Add(newEvent);
            context.SaveChanges();

            return Json(new { success = true, id = newEvent.Id });
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var eventItem = context.Events.Find(id);
            if (eventItem == null)
                return HttpNotFound();

            ViewBag.Categories = context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            return View(eventItem);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event model)
        {
            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index", "Schedule"); // veya takvime dönmek istediğin sayfa
            }
            return View(model);
        }

        //MVCContext context = new MVCContext();

        //[HttpGet]
        //public JsonResult GetCategories()
        //{
        //    var categories = context.Categories.ToList();
        //    return Json(categories, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public JsonResult GetEvents()
        //{
        //    var events = context.Events.Include(e => e.Category).ToList();

        //    var eventList = events.Select(e => new
        //    {
        //        id = e.Id,
        //        title = e.Title,
        //        start = e.Start?.ToString("s"),
        //        end = e.End?.ToString("s"),
        //        allDay = e.AllDay,
        //        backgroundColor = e.Category.CategoryColor,
        //        borderColor = e.Category.CategoryColor,
        //        categoryId = e.CategoryId
        //    }).ToList();

        //    return Json(eventList, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult SaveEvent(Event e)
        //{
        //    if (e.Id > 0)
        //    {
        //        var existingEvent = context.Events.Find(e.Id);
        //        if (existingEvent != null)
        //        {
        //            existingEvent.Title = e.Title;
        //            existingEvent.Start = e.Start;
        //            existingEvent.End = e.End;
        //            existingEvent.AllDay = e.AllDay;
        //            existingEvent.CategoryId = e.CategoryId;
        //        }
        //    }
        //    else
        //    {
        //        context.Events.Add(e);
        //    }

        //    context.SaveChanges();
        //    return Json(new { status = "success" });
        //}

        //[HttpPost]
        //public JsonResult DeleteEvent(int id)
        //{
        //    var ev = context.Events.Find(id);
        //    if (ev != null)
        //    {
        //        context.Events.Remove(ev);
        //        context.SaveChanges();
        //    }
        //    return Json(new { status = "deleted" });
        //}

        //[HttpPost]
        //public JsonResult UpdateEvent(int id, DateTime start, DateTime? end)
        //{
        //    var existingEvent = context.Events.FirstOrDefault(e => e.Id == id);

        //    if (existingEvent != null)
        //    {
        //        existingEvent.Start = start;
        //        existingEvent.End = end;
        //        context.SaveChanges();
        //        return Json(new { success = true });
        //    }

        //    return Json(new { success = false, message = "Event not found." });
        //}

        //[HttpGet]
        //public JsonResult GetExternalEvents()
        //{
        //    var events = context.Events
        //        .Include(e => e.Category)
        //        .Where(e => e.Start == null)
        //        .Select(e => new
        //        {
        //            id = e.Id,
        //            title = e.Title,
        //            backgroundColor = e.Category.CategoryColor,
        //            borderColor = e.Category.CategoryColor,
        //            categoryId = e.CategoryId
        //        }).ToList();

        //    return Json(events, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult CreateEvent(string title, DateTime start, bool allDay, int categoryId)
        //{
        //    var newEvent = new Event
        //    {
        //        Title = title,
        //        Start = start,
        //        AllDay = allDay,
        //        CategoryId = categoryId
        //    };

        //    context.Events.Add(newEvent);
        //    context.SaveChanges();

        //    return Json(new { success = true, id = newEvent.Id });
        //}
    }

}