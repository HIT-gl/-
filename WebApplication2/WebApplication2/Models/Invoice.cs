using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime Deadline { get; set; }
        public string PayerName { get; set; }
        public string PayerAddr { get; set; }
        public decimal PayerTel { get; set; }
        public string ReceiverName { get; set; }
        public string RecevierAddr { get; set; }
        public decimal ReceiverTel { get; set; }
        public string Goods { get; set; }
        public decimal Amount { get; set; }
    }
}