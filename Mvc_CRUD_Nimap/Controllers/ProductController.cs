using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_CRUD_Nimap.Models;
using PagedList;

using PagedList.Mvc;
namespace Mvc_CRUD_Nimap.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ServicesContext db = new ServicesContext();
        // GET: Class1
        //public ActionResult Index()
        //{
        //    var data = db.product.ToList();
        //    return View(data);
        //}




        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 2;
            var products = db.product.OrderBy(x => x.ProductName).ToPagedList(pageNumber, pageSize);
            return View(products);


        }



        //Create
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Product e)
        {
            if (ModelState.IsValid == true)
            {
                db.product.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Not Saved')</script>");
                }
            }
            return View();
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var row = db.product.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Product e)
        {
            db.Entry(e).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Saved')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Not modified')</script>");
            }
            return View();
        }


        //DELETE
        public ActionResult Delete(int id)
        {
            var row = db.product.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(Product e)
        {
            db.Entry(e).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.DeleteMessage = ("<script>alert('Data Delted')</script>");
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DeleteMessage = ("<script>alert('Data Not Deleted')</script>");
            }
            return View();

        }
    }
}