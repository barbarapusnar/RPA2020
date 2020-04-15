using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BazaNajprej.Models;

namespace BazaNajprej.Controllers
{
    public class MentorController : Controller
    {
        private Entities db = new Entities();

        // GET: Mentor
        public ActionResult Index()
        {
            return View(db.Mentor.OrderBy(a=>a.MenPriimek).ToList());
        }

        // GET: Mentor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentor.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // GET: Mentor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mentor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenId,MenIme,MenPriimek,MenSlika,MenVloga,MenNaziv,MenUstanova,UserID")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Mentor.Add(mentor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mentor);
        }

        // GET: Mentor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentor.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenId,MenIme,MenPriimek,MenSlika,MenVloga,MenNaziv,MenUstanova,UserID")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mentor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mentor);
        }

        // GET: Mentor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentor.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mentor mentor = db.Mentor.Find(id);
            db.Mentor.Remove(mentor);
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
