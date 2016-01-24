
using StarWarsUniverse.Model;

public class StarWarsContext : DbContext
{
    public StarWarsContext() : base("StarWarsDB") { }
    public DbSet<SWMovie> SWMovies { get; set; }
    protected override void OnModelCreating(DbModelBuilder builder)
    {
        builder.Entity<SWResource>().HasKey(t => t.ResourceUri);
    }
}