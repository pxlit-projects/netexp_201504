namespace KamersInVlaanderenDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Value", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "Value");
        }
    }
}
