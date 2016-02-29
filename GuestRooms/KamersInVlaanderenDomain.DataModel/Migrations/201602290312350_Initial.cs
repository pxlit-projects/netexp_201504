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
                        Id = c.Int(nullable: false),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        BoxNumber = c.String(),
                        PostalCode = c.String(),
                        CityName = c.String(),
                        MainCityName = c.String(),
                        GuestRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestRooms", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GuestRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessProductGroupId = c.Int(nullable: false),
                        BusinessProductId = c.Int(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        ProductDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Id = c.Int(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        GuestRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestRooms", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestRoomId = c.Int(nullable: false),
                        User = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuestRooms", t => t.GuestRoomId, cascadeDelete: true)
                .Index(t => t.GuestRoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "GuestRoomId", "dbo.GuestRooms");
            DropForeignKey("dbo.Locations", "Id", "dbo.GuestRooms");
            DropForeignKey("dbo.ImageURLs", "GuestRoomId", "dbo.GuestRooms");
            DropForeignKey("dbo.Addresses", "Id", "dbo.GuestRooms");
            DropIndex("dbo.Ratings", new[] { "GuestRoomId" });
            DropIndex("dbo.Locations", new[] { "Id" });
            DropIndex("dbo.ImageURLs", new[] { "GuestRoomId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Locations");
            DropTable("dbo.ImageURLs");
            DropTable("dbo.GuestRooms");
            DropTable("dbo.Addresses");
        }
    }
}
