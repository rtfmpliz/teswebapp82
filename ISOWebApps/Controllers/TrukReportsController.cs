using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISOWebApps.Models;

namespace ISOWebApps.Controllers
{
    public class TrukReportsController : Controller
    {
        private ISOEntities db = new ISOEntities();

        // GET: TrukReports
        public ActionResult Index()
        {
            return View(db.TrukReports.ToList());
        }

        // GET: TrukReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukReport trukReport = db.TrukReports.Find(id);
            if (trukReport == null)
            {
                return HttpNotFound();
            }
            return View(trukReport);
        }

        // GET: TrukReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrukReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NoPolisi,Driver,AsstDriver,Tujuan,Berangkat,Pulang,MuatanBerangkat,QtyMuatanBerangkat,MuatanPulang,QtyMuatanPulang")] TrukReport trukReport)
        {
            if (ModelState.IsValid)
            {
                db.TrukReports.Add(trukReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trukReport);
        }

        // GET: TrukReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukReport trukReport = db.TrukReports.Find(id);
            if (trukReport == null)
            {
                return HttpNotFound();
            }
            return View(trukReport);
        }

        // POST: TrukReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NoPolisi,Driver,AsstDriver,Tujuan,Berangkat,Pulang,MuatanBerangkat,QtyMuatanBerangkat,MuatanPulang,QtyMuatanPulang")] TrukReport trukReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trukReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trukReport);
        }

        // GET: TrukReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukReport trukReport = db.TrukReports.Find(id);
            if (trukReport == null)
            {
                return HttpNotFound();
            }
            return View(trukReport);
        }

        // POST: TrukReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrukReport trukReport = db.TrukReports.Find(id);
            db.TrukReports.Remove(trukReport);
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
