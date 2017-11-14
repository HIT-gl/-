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
    public class ProfitsController : Controller
    {
        private ProfitDBContext db = new ProfitDBContext();

        // GET: Profits
        public ActionResult Index()
        {
            return View(db.Profits.ToList());
        }

        // GET: Profits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profits.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }

        // GET: Profits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,SalesRevenue,SalesCost,OperatingExpenses,Tax")] Profit profit)
        {
            if (ModelState.IsValid)
            {
                db.Profits.Add(profit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profit);
        }

        // GET: Profits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profits.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }

        // POST: Profits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SalesRevenue,SalesCost,OperatingExpenses,Tax")] Profit profit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profit);
        }

        // GET: Profits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profits.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }

        // POST: Profits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profit profit = db.Profits.Find(id);
            db.Profits.Remove(profit);
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
