using Microsoft.EntityFrameworkCore;
using SmartCityApi.Models;

namespace SmartCityApi.Db
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
        : base(options)
        {
        }

        public DbSet<News> News { get; set; } = null!;

    }
}
