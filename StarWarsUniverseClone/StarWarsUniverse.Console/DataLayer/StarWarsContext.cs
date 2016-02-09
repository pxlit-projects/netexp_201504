using StarWarsUniverse.Model;
using System.Data.Entity;

public class StarWarsContext : DbContext
{
    public StarWarsContext() : base("StarWarsDB") { }
    public DbSet<SWMovie> SWMovies { get; set; }
    public DbSet<SWPlanet> SWPlanets { get; set; }
    protected override void OnModelCreating(DbModelBuilder builder)
    {
        builder.Entity<SWMovie>().HasKey(m => m.ResourceUri);
        builder.Entity<SWPlanet>().HasKey(p => p.ResourceUri);
        builder.Entity<SWMovie>()
               .HasMany<SWPlanet>(m => m.Planets)
               .WithMany(p => p.Films)
               .Map(cs =>
               {
                   cs.MapLeftKey("SWMovie_ResourceUri");
                   cs.MapRightKey("SWPlanet_ResourceUri");
                   cs.ToTable("SWPlanetsSWMovies");
               });



        
    }
    
}