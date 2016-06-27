using System.Data.Entity;
using TIS.Data.Models;

namespace TIS.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
