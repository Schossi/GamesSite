using GamesSiteMain.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Services
{
    public class DBSeeder:IDBSeeder
    {
        public const string AdminName = "Admin@IDidGame.com";
        public const string AdminRoleName = "Admin";

        private IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DBSeeder(
            IConfiguration configuration,
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public async Task SeedAsync()
        {
            ApplicationUser adminUser = await _userManager.FindByNameAsync(AdminName);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = AdminName,
                };

                await _userManager.CreateAsync(adminUser, _configuration["AdminPassword"]);
            }

            IdentityRole adminRole = await _roleManager.FindByNameAsync(AdminRoleName);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(AdminRoleName);

                IdentityResult result = await _roleManager.CreateAsync(adminRole);
            }

            if (!await _userManager.IsInRoleAsync(adminUser, AdminRoleName))
            {
                await _userManager.AddToRoleAsync(adminUser, AdminRoleName);
            }
        }
    }
}
