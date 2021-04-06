namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changefac12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "ItemDetailsId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "ItemDetailsId");
        }
    }
}
