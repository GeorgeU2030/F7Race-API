using Microsoft.EntityFrameworkCore;
using f7Race_API.Models;
using f7Race_API.Models.DTOS;

namespace f7Race_API.Data {
    public class F7Db : DbContext {
        public F7Db(DbContextOptions<F7Db> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonBrand> SeasonBrands { get; set; }
        public DbSet<SeasonRace> SeasonRaces { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TrophyCountDto>().HasNoKey();
        }
        
    }
}