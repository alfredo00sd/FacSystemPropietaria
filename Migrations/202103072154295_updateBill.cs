namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Bill_Id", "dbo.Bills");
            DropIndex("dbo.Items", new[] { "Bill_Id" });
            AddColumn("dbo.Bills", "ItemDetailsId", c => c.String());
            DropColumn("dbo.Items", "Bill_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Bill_Id", c => c.Int());
            DropColumn("dbo.Bills", "ItemDetailsId");
            CreateIndex("dbo.Items", "Bill_Id");
            AddForeignKey("dbo.Items", "Bill_Id", "dbo.Bills", "Id");
        }
    }
}
