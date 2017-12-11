namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ii : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        PayerName = c.String(),
                        PayerAddr = c.String(),
                        PayerTel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiverName = c.String(),
                        RecevierAddr = c.String(),
                        ReceiverTel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Goods = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SalesRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingExpenses = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Wages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Employeeid = c.Int(nullable: false),
                        EmployeeName = c.String(),
                        SalaryStandards = c.Int(nullable: false),
                        AttendanceDays = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wages");
            DropTable("dbo.Profits");
            DropTable("dbo.Invoices");
        }
    }
}
