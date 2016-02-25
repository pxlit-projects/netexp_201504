namespace KamersInVlaanderenDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        GuestroomId = c.Int(nullable: false),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GuestRooms", t => t.GuestroomId, cascadeDelete: true)
                .Index(t => t.GuestroomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "GuestroomId", "dbo.GuestRooms");
            DropIndex("dbo.Ratings", new[] { "GuestroomId" });
            DropTable("dbo.Ratings");
        }
    }
}
