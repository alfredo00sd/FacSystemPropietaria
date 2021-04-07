namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingaccountseat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountSeats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CustomerId = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        MType = c.String(),
                        SeatDate = c.String(),
                        SeatAmount = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountSeats");
        }
    }
}
