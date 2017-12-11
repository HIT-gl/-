using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReportsController : Controller
    {
        private ReportDBContext db = new ReportDBContext();

        // GET: Reports
        public ActionResult Index()
        {
            
            
            if (db.Invoices.ToList().Count!=0&db.Profits.ToList().Count!=0& db.Wages.ToList().Count != 0)
             {
                SumRevenue();
             }
                    
            
            return View(db.Reports.ToList());
        }

        public ActionResult Homeback()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Revenue,OperatingExpenses,OperatingProfit,Tax,ProfitTax")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SumRevenue()
        {
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;
            int S5 = 0;
            foreach (var x in db.Invoices.ToList()) 
            {
                S1 +=(int)x.Amount;
                S2 += (int)x.Amount;
            }
            foreach (var x in db.Wages.ToList())
            {
                S2 -= (int)x.Amount;

            }
            foreach (var x in db.Profits.ToList())
            {
                S1 = S1 + (int)x.SalesRevenue;
                S2 = S2 + (int)x.SalesRevenue - (int)x.SalesCost - (int)x.OperatingExpenses;
                S3 += (int)x.OperatingExpenses;
                S4 = S4 + S2 - (int)x.Tax;
                S5 += (int)x.Tax;
            }
            if(db.Reports.ToList().Count == 0)
            {
                Report report = new Report();
                report.Revenue = S1;
                report.OperatingProfit = S2;
                report.OperatingExpenses = S3;
                report.ProfitTax = S4;
                report.Tax = S5;
                db.Reports.Add(report);
                db.SaveChanges();

            }
           else
            {
                db.Reports.Remove(db.Reports.ToList()[0]);
                db.SaveChanges();
                Report report = new Report();
                report.Revenue = S1;
                report.OperatingProfit = S2;
                report.OperatingExpenses = S3;
                report.ProfitTax = S4;
                report.Tax = S5;
                db.Reports.Add(report);
                db.SaveChanges();

            }


            
         }
        
        public ActionResult Edit([Bind(Include = "id,Revenue,OperatingExpenses,OperatingProfit,Tax,ProfitTax")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }
        public FileResult ExportExcel(int? id)
        {
            var sbHtml = new StringBuilder();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            Report baobiao = db.Reports.Find(id);
            var llstTitle = new List<string> { "发票日期", "发票编号", "创建时间" };
            var itemb = new List<string> { "公司名称", "公司地址", "公司联系方式" };

        /**    sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "指标");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", fapiao.ReceiverName);
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            **/
            var itemd = new List<string> { "指标","","","报表" };
            foreach (var item in itemd)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
         //       sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", fapiao.InvoiceNumber);
            }
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "收入");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", baobiao.Revenue);
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "运营开支");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", baobiao.OperatingExpenses);
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "营业利润");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", baobiao.OperatingProfit);
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "税");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", baobiao.Tax);
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "税后利润");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", baobiao.ProfitTax);
            sbHtml.Append("</tr>");
            sbHtml.Append("</table>");
            //第一种:使用FileContentResult
            byte[] fileContents = Encoding.Default.GetBytes(sbHtml.ToString());
            return File(fileContents, "application/ms-excel", "fileContents.xls");
            /**
            //第二种:使用FileStreamResult
            var fileStream = new MemoryStream(fileContents);
            return File(fileStream, "application/ms-excel", "fileStream.xls");

            //第三种:使用FilePathResult
            //服务器上首先必须要有这个Excel文件,然会通过Server.MapPath获取路径返回.
            var fileName = Server.MapPath("~/Files/fileName.xls");
            return File(fileName, "application/ms-excel", "fileName.xls");
            **/
        }
        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
