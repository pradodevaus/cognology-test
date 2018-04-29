namespace Arf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        FlightNumber = c.String(nullable: false),
                        TravelDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(nullable: false),
                        PassengerCount = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(nullable: false, maxLength: 5),
                        Capacity = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DepatureCityId = c.Int(nullable: false),
                        ArrivalCityId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.ArrivalCityId)
                .ForeignKey("dbo.Cities", t => t.DepatureCityId)
                .Index(t => t.DepatureCityId)
                .Index(t => t.ArrivalCityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 5),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Dob = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Email = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 10),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .Index(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "DepatureCityId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "ArrivalCityId", "dbo.Cities");
            DropIndex("dbo.Passengers", new[] { "BookingId" });
            DropIndex("dbo.Flights", new[] { "ArrivalCityId" });
            DropIndex("dbo.Flights", new[] { "DepatureCityId" });
            DropIndex("dbo.Bookings", new[] { "FlightId" });
            DropTable("dbo.Passengers");
            DropTable("dbo.Cities");
            DropTable("dbo.Flights");
            DropTable("dbo.Bookings");
        }
    }
}
