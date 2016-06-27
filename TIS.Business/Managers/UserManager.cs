using System.Threading.Tasks;
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

        public Task<User> GetUserAsync(int userID)
        {
            return this.repositoryContext.UserRepository.GetAsync(userID);
        }

        public Task<User> GetUserAsync(string email)
        {
            return this.repositoryContext.UserRepository.GetAsync(email);
        }

        public void UpdateUser(User user)
        {
            this.repositoryContext.UserRepository.Update(user);
        }

        public async Task DeleteUserAsync(int userID)
        {
            User user = await this.repositoryContext.UserRepository.GetAsync(userID);
            user.IsDeleted = true;
            this.repositoryContext.UserRepository.Delete(user);
        }
    }
}
