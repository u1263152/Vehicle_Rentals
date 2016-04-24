namespace BC_Rentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Postcode = c.String(),
                        Licence = c.String(),
                    })
                .PrimaryKey(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Rental_ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(nullable: false),
                        Vehicle_ID = c.Int(nullable: false),
                        Rental_Start = c.DateTime(nullable: false),
                        Rental_End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Rental_ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_ID, cascadeDelete: true)
                .Index(t => t.Customer_ID)
                .Index(t => t.Vehicle_ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Vehicle_ID = c.Int(nullable: false, identity: true),
                        Vehicle_Manuf = c.String(),
                        Vehicle_Model = c.String(),
                        Vehicle_Colour = c.String(),
                        Vehicle_Licence = c.String(),
                        Vehicle_Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vehicle_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Vehicle_ID", "dbo.Vehicles");
            DropForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Vehicle_ID" });
            DropIndex("dbo.Rentals", new[] { "Customer_ID" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
        }
    }
}
