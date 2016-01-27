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
    public class OznakaController : Controller
    {
        private PrakseContext db = new PrakseContext();

        // GET: Oznaka
        public ActionResult Index()
        {
            return View(db.Oznake.ToList());
        }

        // GET: Oznaka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oznaka oznaka = db.Oznake.Find(id);
            if (oznaka == null)
            {
                return HttpNotFound();
            }
            return View(oznaka);
        }

        // GET: Oznaka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oznaka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OznakaID,Naziv")] Oznaka oznaka)
        {
            if (ModelState.IsValid)
            {
                db.Oznake.Add(oznaka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oznaka);
        }

        // GET: Oznaka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oznaka oznaka = db.Oznake.Find(id);
            if (oznaka == null)
            {
                return HttpNotFound();
            }
            return View(oznaka);
        }

        // POST: Oznaka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OznakaID,Naziv")] Oznaka oznaka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oznaka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oznaka);
        }

        // GET: Oznaka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oznaka oznaka = db.Oznake.Find(id);
            if (oznaka == null)
            {
                return HttpNotFound();
            }
            return View(oznaka);
        }

        // POST: Oznaka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oznaka oznaka = db.Oznake.Find(id);
            db.Oznake.Remove(oznaka);
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
