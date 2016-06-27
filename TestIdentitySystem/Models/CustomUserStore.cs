using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TIS.Business;
using TIS.Data.Models;

namespace TestIdentitySystem.Models
{
    public class CustomUserStore : IUserStore<CustomUser, int>
    {
        private BusinessContext businessContext;

        public CustomUserStore(BusinessContext businessContext)
        {
            this.businessContext = businessContext;
        }

        public async Task CreateAsync(CustomUser customUser)
        {
            User user = new User
            {
                Email = customUser.UserName,
            };

            this.businessContext.UserManager.AddUser(user);
            await Task.Delay(0);
        }

        public Task DeleteAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<CustomUser> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }
    }
}