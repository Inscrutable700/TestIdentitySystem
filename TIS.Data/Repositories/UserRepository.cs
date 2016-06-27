using System.Data.Entity;
using System.Linq;
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

        public override User Get(int id)
        {
            return this.dataContext.Users.SingleOrDefault(u => u.ID == id);
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
