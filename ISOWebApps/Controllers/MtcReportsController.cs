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
    public class MtcReportsController : Controller
    {
        private ISOEntities db = new ISOEntities();

        // GET: MtcReports
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Mesin" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "ReportDate" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var MtcReports = from ts in db.MtcReports
                             select ts;
            if (!String.IsNullOrEmpty(searchString))
            {
                MtcReports = MtcReports.Where(ts => ts.Mesin.Contains(searchString)|| ts.Unit.Contains(searchString) || ts.Part.Contains(searchString) || ts.Kerusakan.Contains(searchString) || ts.PartsPengganti.Contains(searchString) );
            }
            switch (sortOrder)
            {
                case "Mesin":
                    MtcReports = MtcReports.OrderByDescending(ts => ts.Mesin);
                    break;

                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                case "ReportDate":
                    MtcReports = MtcReports.OrderByDescending(ts => ts.ReportDate);
                    break;
                default:
                    MtcReports = MtcReports.OrderByDescending(ts => ts.ReportDate);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(MtcReports.ToPagedList(pageNumber, pageSize));

            //return View(db.MtcReports.ToList());
        }

        // GET: MtcReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MtcReport mtcReport = db.MtcReports.Find(id);
            if (mtcReport == null)
            {
                return HttpNotFound();
            }
            return View(mtcReport);
        }

        // GET: MtcReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MtcReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DocNumber,ReportDate,Mesin,Unit,Part,Kerusakan,PartsPengganti,Penyimpanan,Stock,Inspection,Repaired")] MtcReport mtcReport)
        {
            if (ModelState.IsValid)
            {
                db.MtcReports.Add(mtcReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mtcReport);
        }

        // GET: MtcReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MtcReport mtcReport = db.MtcReports.Find(id);
            if (mtcReport == null)
            {
                return HttpNotFound();
            }
            return View(mtcReport);
        }

        // POST: MtcReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DocNumber,ReportDate,Mesin,Unit,Part,Kerusakan,PartsPengganti,Penyimpanan,Stock,Inspection,Repaired")] MtcReport mtcReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mtcReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mtcReport);
        }

        // GET: MtcReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MtcReport mtcReport = db.MtcReports.Find(id);
            if (mtcReport == null)
            {
                return HttpNotFound();
            }
            return View(mtcReport);
        }

        // POST: MtcReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MtcReport mtcReport = db.MtcReports.Find(id);
            db.MtcReports.Remove(mtcReport);
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
