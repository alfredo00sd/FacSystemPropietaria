namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBill02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "State");
        }
    }
}
