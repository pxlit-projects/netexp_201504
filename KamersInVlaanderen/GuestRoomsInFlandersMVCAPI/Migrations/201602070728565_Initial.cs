namespace GuestRoomsInFlandersMVCAPI.Migrations
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
                        id = c.Int(nullable: false, identity: true),
                        street = c.String(),
                        houseNumber = c.String(),
                        boxNumber = c.String(),
                        postalCode = c.String(),
                        cityName = c.String(),
                        mainCityName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GuestRooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        businessProductGroupId = c.Int(nullable: false),
                        businessProductId = c.Int(nullable: false),
                        discriminator = c.String(),
                        changedTime = c.DateTime(nullable: false),
                        deleted = c.Int(nullable: false),
                        name = c.String(),
                        addressId = c.Int(nullable: false),
                        locationId = c.Int(nullable: false),
                        distance = c.Double(nullable: false),
                        promotionalRegion = c.String(),
                        cyclingLabel = c.String(),
                        greenKeyLabeled = c.String(),
                        accessibilityLabel = c.String(),
                        closingPeriod = c.String(),
                        nextYearClosingPeriod = c.String(),
                        phone = c.String(),
                        mobile = c.String(),
                        email = c.String(),
                        website = c.String(),
                        facebook = c.String(),
                        twitter = c.String(),
                        flickr = c.String(),
                        instagram = c.String(),
                        productDescription = c.String(),
                        locationType = c.String(),
                        airconditioning = c.Int(nullable: false),
                        balcony = c.Int(nullable: false),
                        bikesAvailable = c.Int(nullable: false),
                        extraBabyBedPossible = c.Int(nullable: false),
                        garden = c.Int(nullable: false),
                        internetConnection = c.Int(nullable: false),
                        jacuzzi = c.Int(nullable: false),
                        noSmoking = c.Boolean(nullable: false),
                        petsAllowed = c.Boolean(nullable: false),
                        playGround = c.Int(nullable: false),
                        sauna = c.Int(nullable: false),
                        snacks = c.Int(nullable: false),
                        solarium = c.Int(nullable: false),
                        specificChildrenFacilities = c.String(),
                        specificSeniorFacilities = c.String(),
                        swimming = c.String(),
                        television = c.Int(nullable: false),
                        vault = c.Int(nullable: false),
                        licenseId = c.Int(nullable: false),
                        pricesId = c.Int(nullable: false),
                        parkingAvailable = c.Int(nullable: false),
                        discountChildren = c.Int(nullable: false),
                        directBookingLink = c.String(),
                        imageURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.addressId, cascadeDelete: true)
                .ForeignKey("dbo.Licenses", t => t.licenseId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.locationId, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.pricesId, cascadeDelete: true)
                .Index(t => t.addressId)
                .Index(t => t.locationId)
                .Index(t => t.licenseId)
                .Index(t => t.pricesId);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        licenceComfortClass = c.String(),
                        licenceStatus = c.String(),
                        licenceLastStatusChangeDate = c.DateTime(nullable: false),
                        licenseTotalNumberOfRooms = c.Int(nullable: false),
                        licenseNumberOfRoomsWithBathShowerAndToilet = c.Int(nullable: false),
                        licenseMaximumNumberOfPersonsInLargestRoom = c.Int(nullable: false),
                        licenseMaximumNumberOfPersonsInAllRooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        x = c.Int(nullable: false),
                        y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        currentYearSingleRoomPerPersonMin = c.Double(nullable: false),
                        currentYearSingleRoomPerPersonMax = c.Double(nullable: false),
                        currentYearDoubleRoomPerPersonMin = c.Double(nullable: false),
                        currentYearDoubleRoomPerPersonMax = c.Double(nullable: false),
                        currentYearHalfBoardPerPersonMin = c.Double(nullable: false),
                        currentYearHalfBoardPerPersonMax = c.Double(nullable: false),
                        currentYearFullBoardPerPersonMin = c.Double(nullable: false),
                        currentYearFullBoardPerPersonMax = c.Double(nullable: false),
                        nextYearSingleRoomPerPersonMin = c.Double(nullable: false),
                        nextYearSingleRoomPerPersonMax = c.Double(nullable: false),
                        nextYearDoubleRoomPerPersonMin = c.Double(nullable: false),
                        nextYearDoubleRoomPerPersonMax = c.Double(nullable: false),
                        nextYearHalfBoardPerPersonMin = c.Double(nullable: false),
                        nextYearHalfBoardPerPersonMax = c.Double(nullable: false),
                        nextYearFullBoardPerPersonMin = c.Double(nullable: false),
                        nextYearFullBoardPerPersonMax = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        guestroomId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GuestRooms", t => t.guestroomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.guestroomId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "userId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "guestroomId", "dbo.GuestRooms");
            DropForeignKey("dbo.GuestRooms", "pricesId", "dbo.Prices");
            DropForeignKey("dbo.GuestRooms", "locationId", "dbo.Locations");
            DropForeignKey("dbo.GuestRooms", "licenseId", "dbo.Licenses");
            DropForeignKey("dbo.GuestRooms", "addressId", "dbo.Addresses");
            DropIndex("dbo.Ratings", new[] { "userId" });
            DropIndex("dbo.Ratings", new[] { "guestroomId" });
            DropIndex("dbo.GuestRooms", new[] { "pricesId" });
            DropIndex("dbo.GuestRooms", new[] { "licenseId" });
            DropIndex("dbo.GuestRooms", new[] { "locationId" });
            DropIndex("dbo.GuestRooms", new[] { "addressId" });
            DropTable("dbo.Users");
            DropTable("dbo.Ratings");
            DropTable("dbo.Prices");
            DropTable("dbo.Locations");
            DropTable("dbo.Licenses");
            DropTable("dbo.GuestRooms");
            DropTable("dbo.Addresses");
        }
    }
}
