using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISOWebApps.DAL;
using ISOWebApps.Models;

namespace ISOWebApps.Controllers
{
    public class KendaraanController : Controller
    {
        private KendaraanContext db = new KendaraanContext();

        // GET: Kendaraan
        public ActionResult Index()
        {
            return View(db.Kendaraans.ToList());
        }

        // GET: Kendaraan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraans.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            return View(kendaraan);
        }

        // GET: Kendaraan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kendaraan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NoPol,TipeKendaraan")] Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Kendaraans.Add(kendaraan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kendaraan);
        }

        // GET: Kendaraan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraans.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            return View(kendaraan);
        }

        // POST: Kendaraan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NoPol,TipeKendaraan")] Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kendaraan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kendaraan);
        }

        // GET: Kendaraan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraans.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            return View(kendaraan);
        }

        // POST: Kendaraan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kendaraan kendaraan = db.Kendaraans.Find(id);
            db.Kendaraans.Remove(kendaraan);
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
