using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TIS.Data.Models;

namespace TIS.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override User Add(User entity)
        {
            entity = this.dataContext.Users.Add(entity);
            this.dataContext.SaveChanges();
            return entity;
        }

        public override void Delete(User entity)
        {
            this.dataContext.Users.Remove(entity);
        }

        public override Task<User> GetAsync(int id)
        {
            return this.dataContext.Users.SingleOrDefaultAsync(u => u.ID == id);
        }

        public Task<User> GetAsync(string email)
        {
            return this.dataContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public override User[] List()
        {
            return this.dataContext.Users.ToArray();
        }

        public override void Update(User entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
            this.dataContext.SaveChanges();
        }
    }
}
