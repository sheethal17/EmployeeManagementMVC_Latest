using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCemployemanage.Models;

namespace MVCemployemanage.Controllers
{
    public class emploController : Controller
    {
        private Model1 db = new Model1();
        // GET: emplo
        public ActionResult Index()
        {
            return View(db.emplo.ToList());
        }



       // GET: emplo/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emptable emptable = db.emplo.Find(id);
            if (emptable == null)
            {
                return HttpNotFound();
            }
              return View(emptable);
        }







        // GET: emplo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emplo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,first_name,lastname,email,dob,gender,password,conformpassword")] emptable emptable)
        {
            
            
                // TODO:
                if (ModelState.IsValid)
                {
                    db.emplo.Add(emptable);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            

            
            
                return View(emptable);
            
        
        }




        // GET: emplo/Edit/5
               // POST: emplo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,first_name,lastname,email,dob,gender,password,conformpassword")] emptable emptable)
        {
            
            
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(emptable).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            
            
            
                return View(emptable);
            
        }




        // GET: emplo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
    emptable emptable = db.emplo.Find(id);
            if (emptable == null)
            {
                return HttpNotFound();
            }
              return View(emptable);
        }

        // POST: emplo/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            // TODO: Add delete logic here
            emptable emptable = db.emplo.Find(id);
            db.emplo.Remove(emptable);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(emptable user)
        {
            var verifi = db.emplo.Where(a => a.email.Equals(user.email) && a.password.Equals(user.password)).SingleOrDefault();
            if (verifi != null)
            {


                Session["User"] = user.email;
                return RedirectToAction("Edit");
            }
            else
            {
                ViewBag.error = "Wrong Password or Email";
                return View();
            }
        }
        public ActionResult Dashboard()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {

                return RedirectToAction("Edit");

            }
        }





    }
    }
