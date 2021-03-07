namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBill01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "Comment", c => c.String(maxLength: 200));
        }
    }
}
