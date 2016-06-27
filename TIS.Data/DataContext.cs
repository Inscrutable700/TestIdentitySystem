using System.Data.Entity;
using TIS.Data.Models;

namespace TIS.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
