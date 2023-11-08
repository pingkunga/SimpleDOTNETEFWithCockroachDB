using Microsoft.EntityFrameworkCore;
using DbExploration.DTO;

namespace DbExploration.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options) {  }

    public DbSet<NoteDTO> Notes => Set<NoteDTO>();
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Driver>(entity =>
        {
                        // One to Many relationship
            entity.HasOne(d => d.Team)
                .WithMany(p => p.Drivers)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Driver_Team");

                        // One to One
                        entity.HasOne(d => d.DriverMedia)
                    .WithOne(i => i.Driver)
                    .HasForeignKey<DriverMedia>(b => b.DriverId);
        });
    }
    */
}