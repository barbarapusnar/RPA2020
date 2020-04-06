using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NajprejKoda.Models;

namespace NajprejKoda.Controllers
{
    public class FilmiController : Controller
    {
        private MojiFilmiContext db = new MojiFilmiContext();

        // GET: Filmi
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }
        public ActionResult Isci(string niz,string ftip)
        {
            //pridobi tipe filmov iz PB
            var tipLista = new List<string>();
            var tipQuery = (from b in db.Films
                            orderby b.Tip
                            select b.Tip).Distinct();
            tipLista.AddRange(tipQuery);
            ViewBag.ftip = new SelectList(tipLista); //posreduj na spletno stran

            var filmi = from a in db.Films
                        select a; //vsi filmi
            if (!string.IsNullOrEmpty(niz))
            {
                filmi = filmi.Where(s => s.Naslov.Contains(niz));
            } //filter po naslovu
            if (!string.IsNullOrEmpty(ftip))
            {
                filmi = filmi.Where(s => s.Tip == ftip);
            } //filter po tipu
            return View(filmi);
        }
        // GET: Filmi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Filmi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naslov,Leto,Tip,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Filmi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Filmi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naslov,Leto,Tip,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Filmi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Filmi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
