using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Character> Characters { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Campaign>().ToTable("Campaigns");
        
        builder.Entity<Character>()
            .HasOne(c => c.Campaign)
            .WithMany(c => c.Characters)
            .HasForeignKey(c => c.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);


        // Identity columns for SQLite
        builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>(entity =>
        {
            entity.Property(e => e.ConcurrencyStamp).HasColumnType("TEXT");
        });

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>(entity =>
        {
            entity.Property(e => e.ConcurrencyStamp).HasColumnType("TEXT");
        });
    }

    private void OnDelete(DeleteBehavior cascade)
    {
        throw new NotImplementedException();
    }
}
