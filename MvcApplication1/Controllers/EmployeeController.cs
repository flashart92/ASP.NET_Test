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
    public class EmployeeController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Employee/

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.FistNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";
            ViewBag.AgeSortParm = sortOrder == "age" ? "age_desc" : "age";
            ViewBag.GenderSortParm = sortOrder == "gender" ? "gender_desc" : "gender";
            var employees = db.Employees.Include(model => model.ProgrammingLanguage).Include(model => model.Department);

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(model => model.FirstName.Contains(searchString)
                                       || model.LastName.Contains(searchString)
                                       || model.Age.Contains(searchString)
                                       || model.Gender.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "first_name_desc":
                    employees = employees.OrderByDescending(model => model.FirstName);
                    break;
                case "last_name":
                    employees = employees.OrderBy(model => model.LastName);
                    break;
                case "last_name_desc":
                    employees = employees.OrderByDescending(model => model.LastName);
                    break;
                case "age":
                    employees = employees.OrderBy(model => model.Age);
                    break;
                case "age_desc":
                    employees = employees.OrderByDescending(model => model.Age);
                    break;
                case "gender":
                    employees = employees.OrderBy(model => model.Gender);
                    break;
                case "gender_desc":
                    employees = employees.OrderByDescending(model => model.Gender);
                    break;
                default:
                    employees = employees.OrderBy(model => model.FirstName);
                    break;
            }
            return View(employees.ToList());
        }

        public JsonResult AutoCompleteFirstName(string term)
        {
            var result = (from model in db.Employees
                          where model.FirstName.ToLower().Contains(term.ToLower())
                          select new { model.FirstName }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language", employee.ProgrammingLanguageId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language", employee.ProgrammingLanguageId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
   
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language", employee.ProgrammingLanguageId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language", employee.ProgrammingLanguageId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Language", employee.ProgrammingLanguageId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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