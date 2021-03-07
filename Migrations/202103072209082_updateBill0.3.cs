namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBill03 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "State", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "State", c => c.String());
        }
    }
}
