namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingdetailmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BillDetails");
        }
    }
}
