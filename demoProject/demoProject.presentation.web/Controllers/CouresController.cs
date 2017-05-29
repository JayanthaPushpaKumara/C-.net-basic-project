using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IJSE.Student.DataAccess.DLL;
using demoProject.common.model;

namespace demoProject.presentation.web.Controllers
{
    public class CouresController : Controller
    {
        private demoProjectContext db = new demoProjectContext();

        // GET: Coures
        public ActionResult Index()
        {
            return View(db.Course.ToList());
        }

        // GET: Coures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CouresModel couresModel = db.Course.Find(id);
            if (couresModel == null)
            {
                return HttpNotFound();
            }
            return View(couresModel);
        }

        // GET: Coures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Credits")] CouresModel couresModel)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(couresModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(couresModel);
        }

        // GET: Coures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CouresModel couresModel = db.Course.Find(id);
            if (couresModel == null)
            {
                return HttpNotFound();
            }
            return View(couresModel);
        }

        // POST: Coures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Credits")] CouresModel couresModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(couresModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(couresModel);
        }

        // GET: Coures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CouresModel couresModel = db.Course.Find(id);
            if (couresModel == null)
            {
                return HttpNotFound();
            }
            return View(couresModel);
        }

        // POST: Coures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CouresModel couresModel = db.Course.Find(id);
            db.Course.Remove(couresModel);
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
