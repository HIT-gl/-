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
    public class InvoicesController : Controller
    {
        private ReportDBContext db = new ReportDBContext();

        // GET: Invoices
        public ActionResult Index(string searchString)
        {

            var invoices = db.Invoices.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                for (int i = invoices.Count - 1; i >= 0; i--)
                {
                    Boolean exist = false;
                    foreach (var x in invoices)
                    {
                        string s = invoices[i].InvoiceNumber.ToString();

                        if (s == searchString)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        invoices.RemoveAt(i);
                    }


                }
            }
            return View(invoices);
        }

        public ActionResult Homeback()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,InvoiceNumber,InvoiceDate,Deadline,PayerName,PayerAddr,PayerTel,ReceiverName,RecevierAddr,ReceiverTel,Goods,Amount")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,InvoiceNumber,InvoiceDate,Deadline,PayerName,PayerAddr,PayerTel,ReceiverName,RecevierAddr,ReceiverTel,Goods,Amount")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }
        


        // GET: Invoices
        

        public FileResult ExportExcel(int? id)
        {
            var sbHtml = new StringBuilder();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            Invoice fapiao = db.Invoices.Find(id);
            var llstTitle = new List<string> { "发票日期", "发票编号", "创建时间" };
            var itemb = new List<string> { "公司名称" , "公司地址" , "公司联系方式" };
             
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "公司名称");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>",fapiao.ReceiverName);
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            var itemd = new List<string> { "发票编号" };
            foreach (var item in itemd)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", fapiao.InvoiceNumber);
            }
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "公司地址");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>",fapiao.RecevierAddr);
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", "Tel:");
            sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", fapiao.ReceiverTel);
            sbHtml.Append("</tr>");
            var lstTitle = new List<string> { "顾客姓名", "联系方式", "商品", "金额", "发票日期" };
            sbHtml.Append("<tr>");
            foreach (var item in lstTitle)
            {
                
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
                
            }
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", fapiao.PayerName);
            sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", fapiao.PayerTel);
            sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", fapiao.Goods);
            sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", fapiao.Amount);
            sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", fapiao.InvoiceDate);
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
        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
