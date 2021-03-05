namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeData_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "EmployeeData_Id");
            AddForeignKey("dbo.AspNetUsers", "EmployeeData_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "EmployeeData_Id", "dbo.Employees");
            DropIndex("dbo.AspNetUsers", new[] { "EmployeeData_Id" });
            DropColumn("dbo.AspNetUsers", "EmployeeData_Id");
        }
    }
}
