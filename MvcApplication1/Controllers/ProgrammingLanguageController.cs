using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /ProgrammingLanguage/

        public ActionResult Index()
        {
            return View(db.ProgrammingLanguages.ToList());
        }

        //
        // GET: /ProgrammingLanguage/Details/5

        public ActionResult Details(int id = 0)
        {
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        //
        // GET: /ProgrammingLanguage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProgrammingLanguage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgrammingLanguage programminglanguage)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammingLanguages.Add(programminglanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programminglanguage);
        }

        //
        // GET: /ProgrammingLanguage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        //
        // POST: /ProgrammingLanguage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgrammingLanguage programminglanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programminglanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programminglanguage);
        }

        //
        // GET: /ProgrammingLanguage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        //
        // POST: /ProgrammingLanguage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            db.ProgrammingLanguages.Remove(programminglanguage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}