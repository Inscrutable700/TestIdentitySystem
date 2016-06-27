using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace TestIdentitySystem.Models
{
    public class CustomSignInManager : SignInManager<CustomUser, int>
    {
        private UserManager<CustomUser, int> userManager;

        public CustomSignInManager(UserManager<CustomUser, int> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            this.userManager = userManager;
        }

        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(CustomUser user)
        {
            return user.GenerateUserIdentityAsync((CustomUserManager)userManager);
        }
    }
}