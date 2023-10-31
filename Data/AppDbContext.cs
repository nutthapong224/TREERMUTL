using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TREERMUTL.Models;

namespace TREERMUTL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TREERMUTLCREATE> TREERMUTLCREATESS { get; set; }
        
    }
}
