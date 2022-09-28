using BST.Models;
using Microsoft.EntityFrameworkCore;

namespace BST
{
    public class BSTDbContext : DbContext
    {
        public DbSet<Map> Maps { get; set; } = null!;
        public DbSet<MapPool> MapPools { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseNpgsql(getConString(), t => t.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.MapPools)
                    .WithOne(e => e.Model)
                    .HasForeignKey(e => e.ModelId);
            });
            
            modelBuilder.Entity<MapPool>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Maps)
                    .WithOne(e => e.MapPool)
                    .HasForeignKey(e => e.BeatSaverId);
                
                entity.HasOne(e => e.Owner);
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.MapPool)
                    .WithMany(e => e.Maps)
                    .HasForeignKey(e => e.MapPool.Id);

                
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Model)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.ScoreSaberUsers);
            });
        }
        
        private string getConString()
        {
            var db = "bst";

            var envPW = Environment.GetEnvironmentVariable("BST_DB_PW");
            var envUser = Environment.GetEnvironmentVariable("BST_DB_USER");
            var envHost = Environment.GetEnvironmentVariable("BST_DB_HOST");

            var password = envPW.TryGetValue("postgres");
            var user = envUser.TryGetValue("postgres");
            var host = envHost.TryGetValue("localhost");

#if DEBUG
            return $"Host={host};Database={db};Username={user};Password={password};Include Error Detail=true";
#else
            return $"Host={host};Database={db};Username={user};Password={password}";
#endif

        }
    }
    
    public static class Extensions
    {
        public static string TryGetValue(this string? s, string def)
        {
            return s ?? def;
        }
    }
}