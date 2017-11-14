using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class WagesController : Controller
    {
        private WageDBContext db = new WageDBContext();

        // GET: Wages
        public ActionResult Index()
        {
            return View(db.Wages.ToList());
        }

        // GET: Wages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = db.Wages.Find(id);
            if (wage == null)
            {
                return HttpNotFound();
            }
            return View(wage);
        }

        // GET: Wages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wages/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Employeeid,EmployeeName,SalaryStandards,AttendanceDays,Amount")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                db.Wages.Add(wage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wage);
        }

        // GET: Wages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = db.Wages.Find(id);
            if (wage == null)
            {
                return HttpNotFound();
            }
            return View(wage);
        }

        // POST: Wages/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Employeeid,EmployeeName,SalaryStandards,AttendanceDays,Amount")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wage);
        }

        // GET: Wages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wage wage = db.Wages.Find(id);
            if (wage == null)
            {
                return HttpNotFound();
            }
            return View(wage);
        }

        // POST: Wages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wage wage = db.Wages.Find(id);
            db.Wages.Remove(wage);
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
