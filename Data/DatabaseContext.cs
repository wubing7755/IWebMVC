using IWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace IWebMVC.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasKey(p => p.Id);
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void InitializeSeedData()
        {
            if(!this.Players.Any())
            {
                this.Players.AddRange(
                    new Player
                    {
                        Id = 1,
                        Name = "Li Hua",
                        Description = "First Player"
                    },
                    new Player
                    {
                        Id = 2,
                        Name = "Zhang Ming",
                        Description = "Second Player"
                    });

                this.SaveChanges();
            }
        }

    }
}
