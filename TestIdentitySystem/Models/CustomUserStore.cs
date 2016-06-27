using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TIS.Business;
using TIS.Data.Models;

namespace TestIdentitySystem.Models
{
    public class CustomUserStore :
        IUserStore<CustomUser, int>,
        IUserPasswordStore<CustomUser, int>,
        IUserEmailStore<CustomUser, int>,
        IUserLockoutStore<CustomUser, int>,
        IUserTwoFactorStore<CustomUser, int>
    {
        private BusinessContext businessContext;

        public CustomUserStore(BusinessContext businessContext)
        {
            this.businessContext = businessContext;
        }

        public Task CreateAsync(CustomUser customUser)
        {
            User user = new User
            {
                Email = customUser.UserName,
                Name = customUser.UserName,
                PasswordHash = customUser.PasswordHash,
            };

            user = this.businessContext.UserManager.AddUser(user);
            customUser.Id = user.ID;
            return Task.Delay(0);
        }

        public Task DeleteAsync(CustomUser user)
        {
            return this.businessContext.UserManager.DeleteUserAsync(user.Id);
        }

        public void Dispose()
        {
        }

        public async Task<CustomUser> FindByEmailAsync(string email)
        {
            User user = await this.businessContext.UserManager.GetUserAsync(email);
            CustomUser customUser = null;
            if (user != null)
            {
                customUser = new CustomUser()
                {
                    Id = user.ID,
                    UserName = user.Email,
                };
            }

            return customUser;
        }

        public async Task<CustomUser> FindByIdAsync(int userId)
        {
            User user = await this.businessContext.UserManager.GetUserAsync(userId);
            CustomUser customUser = null;
            if (user != null)
            {
                customUser = new CustomUser()
                {
                    Id = user.ID,
                    UserName = user.Name,
                    Email = user.Email,
                };
            }

            return customUser;
        }

        public async Task<CustomUser> FindByNameAsync(string userName)
        {
            User user = await this.businessContext.UserManager.GetUserAsync(userName);
            CustomUser customUser = null;
            if (user != null)
            {
                customUser = new CustomUser()
                {
                    Id = user.ID,
                    UserName = userName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                };
            }

            return customUser;
        }

        public Task<int> GetAccessFailedCountAsync(CustomUser user)
        {
            return Task.FromResult(user.FailedAccessCount);
        }

        public Task<string> GetEmailAsync(CustomUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(CustomUser user)
        {
            return Task.FromResult(user.IsLockout);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomUser user)
        {
            return Task.FromResult(false);
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomUser user)
        {
            user.FailedAccessCount++;
            return Task.FromResult(user.FailedAccessCount);
        }

        public Task ResetAccessFailedCountAsync(CustomUser user)
        {
            user.FailedAccessCount = 0;
            return Task.Delay(0);
        }

        public Task SetEmailAsync(CustomUser user, string email)
        {
            user.Email = email;
            return Task.Delay(0);
        }

        public Task SetEmailConfirmedAsync(CustomUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(CustomUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.Delay(0);
        }

        public Task SetTwoFactorEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CustomUser customUser)
        {
            User user = await this.businessContext.UserManager.GetUserAsync(customUser.Id);
            user.Email = customUser.Email;
            user.Name = customUser.UserName;
            this.businessContext.UserManager.UpdateUser(user);
        }
    }
}