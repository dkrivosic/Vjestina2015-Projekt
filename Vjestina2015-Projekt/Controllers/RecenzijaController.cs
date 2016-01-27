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
    public class RecenzijaController : Controller
    {
        private PrakseContext db = new PrakseContext();

        // GET: Recenzija
        public ActionResult Index()
        {
            return View("../Tvrtka/Index", db.Tvrtke.ToList());
        }

        // GET: Recenzija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recenzija recenzija = db.Recenzije.Find(id);
            if (recenzija == null)
            {
                return HttpNotFound();
            }
            return View(recenzija);
        }

        // GET: Recenzija/Create
        public ActionResult Create(string tvrtka)
        {
            ViewBag.Tvrtka = tvrtka;
            return View();
        }

        // POST: Recenzija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecenzijaID,Tvrtka,Korisnik,Naslov,Ocjena,Tekst")] Recenzija recenzija)
        {
            recenzija.Korisnik = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Recenzije.Add(recenzija);
                db.SaveChanges();

                var tv = (from t in db.Tvrtke
                          where t.Ime == recenzija.Tvrtka
                          select t).First();

                return RedirectToAction("../Tvrtka/Details/" + tv.TvrtkaID.ToString());
            }


            return View(recenzija);
        }

        // GET: Recenzija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recenzija recenzija = db.Recenzije.Find(id);
            if (recenzija == null)
            {
                return HttpNotFound();
            }
            return View(recenzija);
        }

        // POST: Recenzija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecenzijaID,Tvrtka,Korisnik,Naslov,Ocjena,Tekst")] Recenzija recenzija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recenzija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recenzija);
        }

        // GET: Recenzija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recenzija recenzija = db.Recenzije.Find(id);
            if (recenzija == null)
            {
                return HttpNotFound();
            }
            return View(recenzija);
        }

        // POST: Recenzija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recenzija recenzija = db.Recenzije.Find(id);
            db.Recenzije.Remove(recenzija);
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
