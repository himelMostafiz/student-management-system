using DLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public UserRoleService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task AddNewRoleAsync()
        {
            var roleList = new List<string>() {
              "Admin",
              "Manager",
              "Supervisor"
            };

            foreach (var roleName in roleList)
            {
                var existingRole = await _roleManager.FindByNameAsync(roleName);

                if (existingRole == null)
                {
                    await _roleManager.CreateAsync(
                          new AppRole()
                          {
                              Name = roleName,
                              NormalizedName = roleName
                          });
                }
            }
        }

        public async Task AddNewUserAsync()
        {
            var userList = new List<AppUser>()
            {
                new AppUser()
                {
                    UserName = "himu",
                    Email ="himu@gmail.com",
                    FullName="holud himu"
                },
                new AppUser()
                {
                    UserName = "saku",
                    Email ="saku@gmail.com",
                    FullName = "saku dada"
                },
                new AppUser()
                {
                    UserName = "sadu",
                    Email ="sadu@gmail.com",
                    FullName = "sadu"
                }
            };

            foreach (var user in userList)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    var insertedData = await _userManager.CreateAsync(user,"abc13#");

                    if (insertedData.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
            
        }
    }
}
