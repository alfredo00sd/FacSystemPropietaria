namespace FacSystemPropietaria.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class allOk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.String(nullable: false, maxLength: 11),
                        Customer_Id = c.String(nullable: false, maxLength: 11),
                        Fac_date = c.String(maxLength: 10),
                        Comment = c.String(maxLength: 200),
                        Total = c.String(nullable: false),
                        ITEBIS = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 150),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreationDate = c.String(maxLength: 10),
                        State = c.Boolean(nullable: false),
                        Bill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.Bill_Id)
                .Index(t => t.Bill_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comercial_name_or_social_reason = c.String(nullable: false, maxLength: 150),
                        RNC_or_cedula = c.String(nullable: false, maxLength: 11),
                        Accountable_account = c.String(nullable: false, maxLength: 100),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        Name = c.String(nullable: false, maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 50),
                        Creation_date = c.String(maxLength: 10),
                        Commision_percentage = c.String(nullable: false, maxLength: 20),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Bill_Id", "dbo.Bills");
            DropIndex("dbo.Items", new[] { "Bill_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Items");
            DropTable("dbo.Bills");
        }
    }
}
