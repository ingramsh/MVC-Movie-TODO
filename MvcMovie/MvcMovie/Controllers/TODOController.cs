using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class TODOController : Controller
    {
        private TODODBContext db = new TODODBContext();

        // GET: TODO
        public ActionResult Index()
        {
            return View(db.TODOes.ToList());
        }

        // GET: TODO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOes.Find(id);
            if (tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // GET: TODO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Task,Description,Status")] TODO tODO)
        {
            if (ModelState.IsValid)
            {
                db.TODOes.Add(tODO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tODO);
        }

        // GET: TODO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOes.Find(id);
            if (tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // POST: TODO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Task,Description,Status")] TODO tODO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tODO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tODO);
        }

        // GET: TODO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOes.Find(id);
            if (tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // POST: TODO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODO tODO = db.TODOes.Find(id);
            db.TODOes.Remove(tODO);
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
