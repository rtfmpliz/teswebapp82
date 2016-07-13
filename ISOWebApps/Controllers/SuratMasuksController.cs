using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISOWebApps.Models;
using PagedList;

namespace ISOWebApps.Controllers
{
    public class SuratMasuksController : Controller
    {
        private ISOEntities db = new ISOEntities();

        // GET: SuratMasuks
        public ActionResult Index(string sortOrder, string currentFilter,  string searchString, int? page)
        {
            //return View(db.SuratMasuks.ToList());
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Pengirim" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Kepada" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "TglSuratMasuk" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var SuratMasuks = from s in db.SuratMasuks.Where(a =>  a.Verifikasi != "OK")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                SuratMasuks = SuratMasuks.Where(s => s.Pengirim.Contains(searchString)
                                       || s.Kepada.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Pengirim":
                    SuratMasuks = SuratMasuks.OrderByDescending(s => s.Pengirim);
                    break;
                case "Kepada":
                    SuratMasuks = SuratMasuks.OrderByDescending(s => s.Pengirim);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                case "TglSuratMasuk":
                    SuratMasuks = SuratMasuks.OrderByDescending(s => s.TglSuratMasuk);
                    break;
                default:
                    SuratMasuks = SuratMasuks.OrderByDescending(s => s.TglSuratMasuk);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(SuratMasuks.ToPagedList(pageNumber, pageSize));

            //return View(SuratMasuks.ToList());
        }

        // GET: SuratMasuks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuratMasuk suratMasuk = db.SuratMasuks.Find(id);
            if (suratMasuk == null)
            {
                return HttpNotFound();
            }
            return View(suratMasuk);
        }

        // GET: SuratMasuks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuratMasuks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuratMasukId,TglSuratMasuk,JamSuratMasuk,JumlahSurat,JenisSurat,Pengirim,Kepada,PenerimaSecurity,PenerimaKantor,Verifikasi")] SuratMasuk suratMasuk)
        {
            if (ModelState.IsValid)
            {
                db.SuratMasuks.Add(suratMasuk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suratMasuk);
        }

        // GET: SuratMasuks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuratMasuk suratMasuk = db.SuratMasuks.Find(id);
            if (suratMasuk == null)
            {
                return HttpNotFound();
            }
            return View(suratMasuk);
        }

        // POST: SuratMasuks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuratMasukId,TglSuratMasuk,JamSuratMasuk,JumlahSurat,JenisSurat,Pengirim,Kepada,PenerimaSecurity,PenerimaKantor,Verifikasi")] SuratMasuk suratMasuk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suratMasuk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suratMasuk);
        }

        // GET: SuratMasuks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuratMasuk suratMasuk = db.SuratMasuks.Find(id);
            if (suratMasuk == null)
            {
                return HttpNotFound();
            }
            return View(suratMasuk);
        }

        // POST: SuratMasuks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuratMasuk suratMasuk = db.SuratMasuks.Find(id);
            db.SuratMasuks.Remove(suratMasuk);
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
