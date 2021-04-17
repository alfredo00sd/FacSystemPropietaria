﻿namespace FacSystemPropietaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thelastone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Factura_Id", "dbo.Facturas");
            DropIndex("dbo.Items", new[] { "Factura_Id" });
            DropColumn("dbo.Items", "Factura_Id");
            DropTable("dbo.Facturas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        FacDate = c.String(),
                        FacComment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "Factura_Id", c => c.Int());
            CreateIndex("dbo.Items", "Factura_Id");
            AddForeignKey("dbo.Items", "Factura_Id", "dbo.Facturas", "Id");
        }
    }
}
