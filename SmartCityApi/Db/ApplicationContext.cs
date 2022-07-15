using Microsoft.EntityFrameworkCore;
using SmartCityApi.Models;

namespace SmartCityApi.Db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<News> News => Set<News>();
        public DbSet<Category> Categories => Set<Category>();
        
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Team> Teams => Set<Team>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=217.28.223.127,17160;User Id=user_b351c;Password=6p=E{4KdrR/72z;Database=db_6a944;");
        }
    }
}
