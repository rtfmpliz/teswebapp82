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
    public class TrukKeluarController : Controller
    {
        private KendaraanContext db = new KendaraanContext();

        // GET: TrukKeluar
        public ActionResult Index()
        {
            var trukKeluars = db.TrukKeluars.Include(t => t.Karyawan );

            return View(trukKeluars.ToList());
        }

        // GET: TrukKeluar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukKeluar trukKeluar = db.TrukKeluars.Find(id);
            if (trukKeluar == null)
            {
                return HttpNotFound();
            }
            return View(trukKeluar);
        }

        // GET: TrukKeluar/Create
        public ActionResult Create()
        {
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol");
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "NamaKaryawan");
            return View();
        }

        // POST: TrukKeluar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TglReport,KaryawanID,KendaraanID,Tujuan,JenisMuatanBrkt,TonMuatanBrkt,JenisMuatanPlg,TonMuatanPlg,TglBerangkat,TglPulang")] TrukKeluar trukKeluar)
        {
            if (ModelState.IsValid)
            {
                db.TrukKeluars.Add(trukKeluar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", trukKeluar.KendaraanID);

            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "NamaKaryawan", trukKeluar.KaryawanID);
            return View(trukKeluar);
        }

        // GET: TrukKeluar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukKeluar trukKeluar = db.TrukKeluars.Find(id);
            if (trukKeluar == null)
            {
                return HttpNotFound();
            }
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", trukKeluar.KendaraanID);
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "NamaKaryawan", trukKeluar.KaryawanID);
            return View(trukKeluar);
        }

        // POST: TrukKeluar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TglReport,KaryawanID,KendaraanID,Tujuan,JenisMuatanBrkt,TonMuatanBrkt,JenisMuatanPlg,TonMuatanPlg,TglBerangkat,TglPulang")] TrukKeluar trukKeluar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trukKeluar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KendaraanID = new SelectList(db.Kendaraans, "ID", "NoPol", trukKeluar.KendaraanID);
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "NamaKaryawan", trukKeluar.KaryawanID);
            return View(trukKeluar);
        }

        // GET: TrukKeluar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrukKeluar trukKeluar = db.TrukKeluars.Find(id);
            if (trukKeluar == null)
            {
                return HttpNotFound();
            }
            return View(trukKeluar);
        }

        // POST: TrukKeluar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrukKeluar trukKeluar = db.TrukKeluars.Find(id);
            db.TrukKeluars.Remove(trukKeluar);
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
