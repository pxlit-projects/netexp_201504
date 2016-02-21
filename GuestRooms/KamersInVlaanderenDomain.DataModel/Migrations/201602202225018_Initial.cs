namespace KamersInVlaanderenDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        BoxNumber = c.String(),
                        PostalCode = c.String(),
                        CityName = c.String(),
                        MainCityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessProductGroupId = c.Int(nullable: false),
                        BusinessProductId = c.Int(nullable: false),
                        Name = c.String(),
                        AddressId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        ProductDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.ImageURLs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        GuestRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestRooms", t => t.GuestRoomId, cascadeDelete: true)
                .Index(t => t.GuestRoomId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestRooms", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ImageURLs", "GuestRoomId", "dbo.GuestRooms");
            DropForeignKey("dbo.GuestRooms", "AddressId", "dbo.Addresses");
            DropIndex("dbo.ImageURLs", new[] { "GuestRoomId" });
            DropIndex("dbo.GuestRooms", new[] { "LocationId" });
            DropIndex("dbo.GuestRooms", new[] { "AddressId" });
            DropTable("dbo.Locations");
            DropTable("dbo.ImageURLs");
            DropTable("dbo.GuestRooms");
            DropTable("dbo.Addresses");
        }
    }
}
