using KamersInVlaanderen;
using System.Data.Entity;

namespace KamersInVlaanderenDomain.DataModel
{
    public class KamersContext:DbContext
    {
        public DbSet<GuestRoom> GuestRooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ImageURL> ImageURLs { get; set; }
        //public DbSet<License> Licenses { get; set; }
        //public DbSet<Prices> Prices { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //one-to-many 
            /*modelBuilder.Entity<GuestRoom>()
                        .HasOptional<Standard>(s => s.Standard)
                        .WithMany(s => s.Students)
                        .HasForeignKey(s => s.StdId);*/
            builder.Entity<GuestRoom>().Ignore(g => g.AverageRating);
            builder.Entity<GuestRoom>().Ignore(g => g.distanceFromCoordinates);
        }
    }
    
}
