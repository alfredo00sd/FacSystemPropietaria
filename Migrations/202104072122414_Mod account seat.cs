namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modaccountseat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountSeats", "SeatAmount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountSeats", "SeatAmount", c => c.Int(nullable: false));
        }
    }
}
