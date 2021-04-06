namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changefac : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Items", c => c.String());
            AddColumn("dbo.Bills", "ItemsQ", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "ItemsQ");
            DropColumn("dbo.Bills", "Items");
        }
    }
}
