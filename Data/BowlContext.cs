using Microsoft.EntityFrameworkCore;
using Ishu_Bowl.Models;

namespace Ishu_Bowl.Data
{
    public class BowlContext : DbContext
    {
        public BowlContext(DbContextOptions<BowlContext> options)
            : base(options)
        {
        }

        public DbSet<Bowl> Bowl { get; set; }
    }
}