namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Comercial_name_or_social_reason", c => c.String());
            AlterColumn("dbo.Customers", "RNC_or_cedula", c => c.String());
            AlterColumn("dbo.Customers", "Accountable_account", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Accountable_account", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "RNC_or_cedula", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Customers", "Comercial_name_or_social_reason", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
