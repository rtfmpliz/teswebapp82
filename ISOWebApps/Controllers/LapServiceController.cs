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
    public class LapServiceController : Controller
    {
        private KendaraanContext db = new KendaraanContext();

        // GET: LapService
        public ActionResult Index()
        {
            var lapServices = db.LapServices.Include(l => l.Kendaraan);
            return View(lapServices.ToList());
        }

        // GET: LapService/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LapService lapService = db.LapServices.Find(id);
            if (lapService == null)
            {
                return HttpNotFound();
            }
            return View(lapService);
        }

        // GET: LapService/Create
        public ActionResult Create()
        {
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol");
            return View();
        }

        // POST: LapService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LapServiceID,KendaraanID,Perkiraan,Waktu,Bengkel,AlamatTelp,Keterangan")] LapService lapService)
        {
            if (ModelState.IsValid)
            {
                db.LapServices.Add(lapService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", lapService.KendaraanID);
            return View(lapService);
        }

        // GET: LapService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LapService lapService = db.LapServices.Find(id);
            if (lapService == null)
            {
                return HttpNotFound();
            }
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", lapService.KendaraanID);
            return View(lapService);
        }

        // POST: LapService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LapServiceID,KendaraanID,Perkiraan,Waktu,Bengkel,AlamatTelp,Keterangan")] LapService lapService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lapService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", lapService.KendaraanID);
            return View(lapService);
        }

        // GET: LapService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LapService lapService = db.LapServices.Find(id);
            if (lapService == null)
            {
                return HttpNotFound();
            }
            return View(lapService);
        }

        // POST: LapService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LapService lapService = db.LapServices.Find(id);
            db.LapServices.Remove(lapService);
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
