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
    public class EnrollmentController : Controller
    {
        private demoProjectContext db = new demoProjectContext();

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollment = db.Enrollment.Include(e => e.Course).Include(e => e.Student);
            return View(enrollment.ToList());
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentModel enrollmentModel = db.Enrollment.Find(id);
            if (enrollmentModel == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentModel);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Title");
            ViewBag.StudentID = new SelectList(db.student, "ID", "Lastname");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,StudentID,Grade")] EnrollmentModel enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollmentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Course, "ID", "Title", enrollmentModel.CourseID);
            ViewBag.StudentID = new SelectList(db.student, "ID", "Lastname", enrollmentModel.StudentID);
            return View(enrollmentModel);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentModel enrollmentModel = db.Enrollment.Find(id);
            if (enrollmentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Title", enrollmentModel.CourseID);
            ViewBag.StudentID = new SelectList(db.student, "ID", "Lastname", enrollmentModel.StudentID);
            return View(enrollmentModel);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,StudentID,Grade")] EnrollmentModel enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollmentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Title", enrollmentModel.CourseID);
            ViewBag.StudentID = new SelectList(db.student, "ID", "Lastname", enrollmentModel.StudentID);
            return View(enrollmentModel);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentModel enrollmentModel = db.Enrollment.Find(id);
            if (enrollmentModel == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentModel);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollmentModel enrollmentModel = db.Enrollment.Find(id);
            db.Enrollment.Remove(enrollmentModel);
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
