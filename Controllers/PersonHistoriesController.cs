using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestrOsobZaginionych.Models;

namespace RejestrOsobZaginionych.Controllers
{
    [Authorize]
    public class PersonHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonHistories
        [AllowAnonymous]
        public ActionResult Index()
        {
            var personHistories = db.PersonHistories.Include(p => p.Person);
            return View(personHistories.ToList());
        }

        // GET: PersonHistories/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonHistory personHistory = db.PersonHistories.Find(id);
            if (personHistory == null)
            {
                return HttpNotFound();
            }
            return View(personHistory);
        }

        // GET: PersonHistories/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: PersonHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonHistoryId,PersonId,IsFound,LostDate,FoundDate")] PersonHistory personHistory)
        {
            if (ModelState.IsValid)
            {
                db.PersonHistories.Add(personHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FirstName", personHistory.PersonId);
            return View(personHistory);
        }

        // GET: PersonHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonHistory personHistory = db.PersonHistories.Find(id);
            if (personHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FirstName", personHistory.PersonId);
            return View(personHistory);
        }

        // POST: PersonHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonHistoryId,PersonId,IsFound,LostDate,FoundDate")] PersonHistory personHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FirstName", personHistory.PersonId);
            return View(personHistory);
        }

        // GET: PersonHistories/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonHistory personHistory = db.PersonHistories.Find(id);
            if (personHistory == null)
            {
                return HttpNotFound();
            }
            return View(personHistory);
        }

        // POST: PersonHistories/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonHistory personHistory = db.PersonHistories.Find(id);
            db.PersonHistories.Remove(personHistory);
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
