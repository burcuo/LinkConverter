using Microsoft.EntityFrameworkCore;
using Trendyol.LinkConverter.EntityFramework.Models;

namespace Trendyol.LinkConverter.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShortLinkEntity> ShortLinks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }        
    }
}
