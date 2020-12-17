using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sujitabookstore;

namespace sujitabookstore.Controllers
{
    public class cat_tableController : Controller
    {
        private sujitabooksEntities db = new sujitabooksEntities();

        // GET: cat_table
        public ActionResult Index()
        {
            return View(db.cat_table.ToList());
        }

        // GET: cat_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_table cat_table = db.cat_table.Find(id);
            if (cat_table == null)
            {
                return HttpNotFound();
            }
            return View(cat_table);
        }

        // GET: cat_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name")] cat_table cat_table)
        {
            if (ModelState.IsValid)
            {
                db.cat_table.Add(cat_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_table);
        }

        // GET: cat_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_table cat_table = db.cat_table.Find(id);
            if (cat_table == null)
            {
                return HttpNotFound();
            }
            return View(cat_table);
        }

        // POST: cat_table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name")] cat_table cat_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_table);
        }

        // GET: cat_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_table cat_table = db.cat_table.Find(id);
            if (cat_table == null)
            {
                return HttpNotFound();
            }
            return View(cat_table);
        }

        // POST: cat_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cat_table cat_table = db.cat_table.Find(id);
            db.cat_table.Remove(cat_table);
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
    }
}
