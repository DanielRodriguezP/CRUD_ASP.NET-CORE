using Microsoft.EntityFrameworkCore;
using Store.Web.Data.Entities;

namespace Store.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products{get; set;}

        public DbSet<Stores> Stores { get; set; }
        
    }
}
