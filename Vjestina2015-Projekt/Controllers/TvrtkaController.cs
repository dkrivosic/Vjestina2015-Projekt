using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vjestina2015_Projekt.DAL;
using Vjestina2015_Projekt.Models;

namespace Vjestina2015_Projekt.Controllers
{
    [Authorize]
    public class TvrtkaController : Controller
    {
        private PrakseContext db = new PrakseContext();

        // GET: Tvrtka
        public ActionResult Index(string searchString)
        {
            var tvrtke = from t in db.Tvrtke
                         select t;

            if(!String.IsNullOrEmpty(searchString))
            {
                tvrtke = tvrtke.Where(t => t.Ime.Contains(searchString));
            }

            tvrtke = tvrtke.OrderBy(t => t.Ime);

            return View(tvrtke);
        }

        // GET: Tvrtka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvrtka tvrtka = db.Tvrtke.Find(id);
            if (tvrtka == null)
            {
                return HttpNotFound();
            }

            var recenzijeQry = from r in db.Recenzije
                               where r.Tvrtka == tvrtka.Ime
                               select r;

            ViewBag.Prosjek = (from r in db.Recenzije
                          where r.Tvrtka == tvrtka.Ime
                          select r.Ocjena).DefaultIfEmpty(0).Average();

            ViewBag.Recenzije = new List<Recenzija>(recenzijeQry);

            return View(tvrtka);
        }

        // GET: Tvrtka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tvrtka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TvrtkaID,Ime,Opis")] Tvrtka tvrtka)
        {
            if (ModelState.IsValid)
            {
                db.Tvrtke.Add(tvrtka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tvrtka);
        }

        // GET: Tvrtka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvrtka tvrtka = db.Tvrtke.Find(id);
            if (tvrtka == null)
            {
                return HttpNotFound();
            }
            return View(tvrtka);
        }

        // POST: Tvrtka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TvrtkaID,Ime,Opis")] Tvrtka tvrtka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvrtka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tvrtka);
        }

        // GET: Tvrtka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvrtka tvrtka = db.Tvrtke.Find(id);
            if (tvrtka == null)
            {
                return HttpNotFound();
            }
            return View(tvrtka);
        }

        // POST: Tvrtka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tvrtka tvrtka = db.Tvrtke.Find(id);
            db.Tvrtke.Remove(tvrtka);
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
