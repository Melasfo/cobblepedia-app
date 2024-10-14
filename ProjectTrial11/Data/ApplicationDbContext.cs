using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTrial11.Models;

namespace ProjectTrial11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectTrial11.Models.BaseStat>? BaseStat { get; set; }
        public DbSet<ProjectTrial11.Models.Cobblemon>? Cobblemon { get; set; }
        public DbSet<ProjectTrial11.Models.EggMove>? EggMove { get; set; }
        public DbSet<ProjectTrial11.Models.LevelUpMove>? LevelUpMove { get; set; }
        public DbSet<ProjectTrial11.Models.TMMove>? TMMove { get; set; }
        public DbSet<ProjectTrial11.Models.CType>? CType { get; set; }
        public DbSet<ProjectTrial11.Models.Location>? Location { get; set; }
        public DbSet<ProjectTrial11.Models.Item>? Item { get; set; }
        public DbSet<ProjectTrial11.Models.Move>? Move { get; set; }
        public DbSet<ProjectTrial11.Models.Ability>? Ability { get; set; }
        public DbSet<ProjectTrial11.Models.Nature>? Nature { get; set; }
        public DbSet<ProjectTrial11.Models.Question>? Question { get; set; }
        public DbSet<ProjectTrial11.Models.Comment>? Comment { get; set; }
        public DbSet<ProjectTrial11.Models.News>? News { get; set; }
        public DbSet<CobblemonBaseStat> CobblemonBaseStats { get; set; }
        public DbSet<CobblemonLevelUpMove> CobblemonLevelUpMoves { get; set; }
        public DbSet<CobblemonTMMove> CobblemonTMMoves { get; set; }
        public DbSet<CobblemonEggMove> CobblemonEggMoves { get; set; }
        public DbSet<CobblemonCType> CobblemonCTypes { get; set; }
        public DbSet<CobblemonLocation> CobblemonLocations { get; set; }

        

    }
}