using GameBoi.Models.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBoi.Repository.Layer
{
    public class GameBoiDbContext : DbContext
    {
        public GameBoiDbContext(DbContextOptions<GameBoiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MyGame> MyGames { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.MyGames)
                .WithOne(g => g.Profile)
                .HasForeignKey(g => g.ProfileId);
        }
    }
}
