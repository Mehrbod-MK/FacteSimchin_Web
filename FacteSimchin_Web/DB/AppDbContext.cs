using Microsoft.EntityFrameworkCore;

namespace FacteSimchin_Web.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<GameSessionModel> GameSessions { get; set; }

        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerModel>()
                .HasOne(x => x.GameSession)
                .WithMany(x => x.Players)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
