namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingExpenses = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProfitTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
