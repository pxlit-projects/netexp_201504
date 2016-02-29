using KamersInVlaanderen;
using System.Data.Entity;

namespace KamersInVlaanderenDomain.DataModel
{
    public class KamersContext : DbContext
    {
        public DbSet<GuestRoom> GuestRooms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ImageURL> ImageURLs { get; set; }
        //public DbSet<License> Licenses { get; set; }
        //public DbSet<Prices> Prices { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public KamersContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //one-to-many 
            /*modelBuilder.Entity<GuestRoom>()
                        .HasOptional<Standard>(s => s.Standard)
                        .WithMany(s => s.Students)
                        .HasForeignKey(s => s.StdId);*/

            builder.Entity<GuestRoom>().HasKey(g => g.Id);
            //builder.Entity<GuestRoom>().HasKey(g => g.Id);
            builder.Entity<GuestRoom>().HasOptional(g => g.Location).WithRequired(l => l.GuestRoom);
            builder.Entity<GuestRoom>().HasOptional(g => g.Address).WithRequired(a => a.GuestRoom);
            builder.Entity<GuestRoom>().HasMany<Rating>(g => g.Ratings).WithRequired(r => r.GuestRoom);
            builder.Entity<GuestRoom>().HasMany<ImageURL>(g => g.ImageURLs).WithRequired(i => i.GuestRoom);
            builder.Entity<Rating>().HasKey(r => r.Id);
            builder.Entity<Address>().HasKey(a => a.Id);
            builder.Entity<Location>().HasKey(l => l.Id);
            builder.Entity<ImageURL>().HasKey(i => i.Id);

            builder.Entity<GuestRoom>().Ignore(g => g.AverageRating);
            builder.Entity<GuestRoom>().Ignore(g => g.distanceFromCoordinates);
            //base.OnModelCreating(builder);
        }
    }
    
}
