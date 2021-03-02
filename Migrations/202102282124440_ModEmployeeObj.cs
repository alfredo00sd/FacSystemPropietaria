namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModEmployeeObj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Creation_date", c => c.String());
            AlterColumn("dbo.Employees", "Commision_percentage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Commision_percentage", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "Creation_date", c => c.String(maxLength: 10));
        }
    }
}
