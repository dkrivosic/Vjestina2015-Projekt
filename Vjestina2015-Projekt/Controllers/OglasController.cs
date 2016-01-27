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
    public class OglasController : Controller
    {
        private PrakseContext db = new PrakseContext();

        // GET: Oglas
        public ActionResult Index(string searchString)
        {
            var oglasi = from o in db.Oglasi
                         select o;

            if(!String.IsNullOrEmpty(searchString))
            {
                oglasi = oglasi.Where(o => o.Naslov.Contains(searchString) || o.Tekst.Contains(searchString));
            }

            oglasi = oglasi.OrderBy(o => o.Tvrtka);

            return View(oglasi);
        }

        // GET: Oglas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.Oglasi.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // GET: Oglas/Create
        public ActionResult Create()
        {
            var tvrtkeQuery = from t in db.Tvrtke
                         orderby t.Ime
                         select t.Ime;

            var oznakeQuery = from o in db.Oznake
                              orderby o.Naziv
                              select o;

            ViewBag.tvrtka = new SelectList(tvrtkeQuery);
            ViewBag.oznake = new SelectList(oznakeQuery);

            return View();
        }

        // POST: Oglas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OglasID,Naslov,Tvrtka,Tekst,Placa")] Oglas oglas, string tvrtka)
        {
            oglas.Tvrtka = tvrtka;
            oglas.Korisnik = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Oglasi.Add(oglas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var tv = from t in db.Tvrtke
            where t.Ime == tvrtka
            select t;

            return View(tv.First());
        }

        // GET: Oglas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.Oglasi.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // POST: Oglas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OglasID,Naslov,Tvrtka,Tekst,Placa")] Oglas oglas)
        {
            oglas.Korisnik = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(oglas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oglas);
        }

        // GET: Oglas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.Oglasi.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // POST: Oglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oglas oglas = db.Oglasi.Find(id);
            db.Oglasi.Remove(oglas);
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
