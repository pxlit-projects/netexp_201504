using KamersInVlaanderen;
using System.Data.Entity;

namespace KamersInVlaanderenDomain.DataModel
{
    public class KamersContext:DbContext
    {
        public DbSet<GuestRoom> GuestRooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<License> Licenses { get; set; }
        //public DbSet<Prices> Prices { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Rating> Ratings { get; set; }
    }
}
