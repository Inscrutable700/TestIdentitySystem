using TIS.Data;
using TIS.Data.Models;

namespace TIS.Business.Managers
{
    public class UserManager : ManagerBase
    {
        public UserManager(RepositoryContext repositoryContext, BusinessContext businessContext)
            : base(repositoryContext, businessContext)
        {
        }

        public User AddUser(User user)
        {
            return this.repositoryContext.UserRepository.Add(user);
        }

        public User GetUser(int userID)
        {
            return this.repositoryContext.UserRepository.Get(userID);
        }
    }
}
