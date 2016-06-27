using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TestIdentitySystem.Models
{
    public class CustomUser : IUser<int>
    {
        public CustomUser() { }

        public CustomUser(int id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsLockout { get; set; }

        public int FailedAccessCount { get; set; }

        public bool EmailConfirmed { get; set; }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync()
        {
            return null;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(CustomUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}