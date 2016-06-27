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

        public Task<ClaimsIdentity> GenerateUserIdentityAsync()
        {
            return null;
        }
    }
}