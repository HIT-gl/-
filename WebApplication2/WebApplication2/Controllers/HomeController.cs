using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invoicestart()
        {
            return RedirectToAction("Index","Invoices");
        }

        public ActionResult Profitstart()
        {
            return RedirectToAction("Index", "Profits");
        }

        public ActionResult Wagestart()
        {
            return RedirectToAction("Index", "Wages");
        }

        public ActionResult Reportstart()
        {
            return RedirectToAction("Index", "Reports");
        }
    }
}