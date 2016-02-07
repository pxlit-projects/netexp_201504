namespace GuestRoomsInFlandersMVCAPI.Migrations
{
    using KamersInVlaanderen;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuestRoomsInFlandersMVCAPI.KamersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuestRoomsInFlandersMVCAPI.KamersContext context)
        {

            /*
            context.Users.AddOrUpdate(
                  p => p.id,
                  new User { name = "TestUser1" },
                  new User { name = "TestUser2" },
                  new User { name = "TestUser3" }
                );*/
        }
    }
}
