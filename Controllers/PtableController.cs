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
    public class PtableController : Controller
    {
        private sujitabooksEntities db = new sujitabooksEntities();

        // GET: Ptable
        public ActionResult Index()
        {
            return View(db.Ptables.ToList());
        }

        // GET: Ptable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ptable ptable = db.Ptables.Find(id);
            if (ptable == null)
            {
                return HttpNotFound();
            }
            return View(ptable);
        }

        // GET: Ptable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ptable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_id,P_name,P_price,P_quantity,P_details,cat_id")] Ptable ptable)
        {
            if (ModelState.IsValid)
            {
                db.Ptables.Add(ptable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ptable);
        }

        // GET: Ptable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ptable ptable = db.Ptables.Find(id);
            if (ptable == null)
            {
                return HttpNotFound();
            }
            return View(ptable);
        }

        // POST: Ptable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_id,P_name,P_price,P_quantity,P_details,cat_id")] Ptable ptable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ptable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ptable);
        }

        // GET: Ptable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ptable ptable = db.Ptables.Find(id);
            if (ptable == null)
            {
                return HttpNotFound();
            }
            return View(ptable);
        }

        // POST: Ptable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ptable ptable = db.Ptables.Find(id);
            db.Ptables.Remove(ptable);
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
