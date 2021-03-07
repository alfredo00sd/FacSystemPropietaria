namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.Bills", "Employee_Id1", "dbo.Employees");
            DropIndex("dbo.Bills", new[] { "Employee_Id1" });
            DropIndex("dbo.Customers", new[] { "Bill_Id" });
            AlterColumn("dbo.Bills", "Employee_Id", c => c.String());
            AlterColumn("dbo.Bills", "Customer_Id", c => c.String());
            AlterColumn("dbo.Bills", "Fac_date", c => c.String());
            AlterColumn("dbo.Bills", "Total", c => c.String());
            AlterColumn("dbo.Bills", "ITEBIS", c => c.String());
            DropColumn("dbo.Bills", "Employee_Id1");
            DropColumn("dbo.Customers", "Bill_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Bill_Id", c => c.Int());
            AddColumn("dbo.Bills", "Employee_Id1", c => c.Int());
            AlterColumn("dbo.Bills", "ITEBIS", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Bills", "Total", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "Fac_date", c => c.String(maxLength: 10));
            AlterColumn("dbo.Bills", "Customer_Id", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Bills", "Employee_Id", c => c.String(nullable: false, maxLength: 11));
            CreateIndex("dbo.Customers", "Bill_Id");
            CreateIndex("dbo.Bills", "Employee_Id1");
            AddForeignKey("dbo.Bills", "Employee_Id1", "dbo.Employees", "Id");
            AddForeignKey("dbo.Customers", "Bill_Id", "dbo.Bills", "Id");
        }
    }
}
