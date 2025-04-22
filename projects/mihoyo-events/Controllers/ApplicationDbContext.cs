public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Event>()
            .HasIndex(e => e.Status);
        
        base.OnModelCreating(builder);
    }
}