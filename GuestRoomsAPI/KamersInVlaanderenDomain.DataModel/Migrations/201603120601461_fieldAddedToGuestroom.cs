namespace KamersInVlaanderenDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldAddedToGuestroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestRooms", "Facebook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuestRooms", "Facebook");
        }
    }
}
