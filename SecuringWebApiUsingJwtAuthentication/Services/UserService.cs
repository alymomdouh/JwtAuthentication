using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SecuringWebApiUsingJwtAuthentication.IServices;
using SecuringWebApiUsingJwtAuthentication.Models;
using SecuringWebApiUsingJwtAuthentication.Settings;

namespace SecuringWebApiUsingJwtAuthentication.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
    }
}
