namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBillObj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Employee_Id1", c => c.Int());
            AddColumn("dbo.Customers", "Bill_Id", c => c.Int());
            CreateIndex("dbo.Bills", "Employee_Id1");
            CreateIndex("dbo.Customers", "Bill_Id");
            AddForeignKey("dbo.Customers", "Bill_Id", "dbo.Bills", "Id");
            AddForeignKey("dbo.Bills", "Employee_Id1", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.Customers", "Bill_Id", "dbo.Bills");
            DropIndex("dbo.Customers", new[] { "Bill_Id" });
            DropIndex("dbo.Bills", new[] { "Employee_Id1" });
            DropColumn("dbo.Customers", "Bill_Id");
            DropColumn("dbo.Bills", "Employee_Id1");
        }
    }
}
