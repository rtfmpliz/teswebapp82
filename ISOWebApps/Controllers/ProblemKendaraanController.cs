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
    public class ProblemKendaraanController : Controller
    {
        private KendaraanContext db = new KendaraanContext();

        // GET: ProblemKendaraan
        public ActionResult Index()
        {
            return View(db.ProblemKendaraan.ToList());
        }

        // GET: ProblemKendaraan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemKendaraan problemKendaraan = db.ProblemKendaraan.Find(id);
            if (problemKendaraan == null)
            {
                return HttpNotFound();
            }
            return View(problemKendaraan);
        }

        // GET: ProblemKendaraan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemKendaraan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProblemKendaraanID,Status,JadwalTunda,Problem")] ProblemKendaraan problemKendaraan)
        {
            if (ModelState.IsValid)
            {
                db.ProblemKendaraan.Add(problemKendaraan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problemKendaraan);
        }

        // GET: ProblemKendaraan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemKendaraan problemKendaraan = db.ProblemKendaraan.Find(id);
            if (problemKendaraan == null)
            {
                return HttpNotFound();
            }
            return View(problemKendaraan);
        }

        // POST: ProblemKendaraan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProblemKendaraanID,Status,JadwalTunda,Problem")] ProblemKendaraan problemKendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemKendaraan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problemKendaraan);
        }

        // GET: ProblemKendaraan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemKendaraan problemKendaraan = db.ProblemKendaraan.Find(id);
            if (problemKendaraan == null)
            {
                return HttpNotFound();
            }
            return View(problemKendaraan);
        }

        // POST: ProblemKendaraan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemKendaraan problemKendaraan = db.ProblemKendaraan.Find(id);
            db.ProblemKendaraan.Remove(problemKendaraan);
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
