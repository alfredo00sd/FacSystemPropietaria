namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changefac1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Productos", c => c.String());
            DropColumn("dbo.Bills", "ItemDetailsId");
            DropColumn("dbo.Bills", "Items");
            DropColumn("dbo.Bills", "ItemsQ");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "ItemsQ", c => c.String());
            AddColumn("dbo.Bills", "Items", c => c.String());
            AddColumn("dbo.Bills", "ItemDetailsId", c => c.String());
            DropColumn("dbo.Bills", "Productos");
        }
    }
}
