﻿using Application.Helper;
using Application.Repositery;
using Domain.Authentication;
using Domain.Enumerable;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Presistance.DataBase;
using Share.Permission.User;

namespace Application.Implementation
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly DataContext _db;
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public DatabaseSeeder(UserManager<User> userManager, RoleManager<Role> roleManager, DataContext db,
            ILogger<DatabaseSeeder> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {

            try
            {
                _db.Database.Migrate();
            }
            catch
            {
                // ignored
            }

            AddAdministrator();
            AddUser();
        }
        private void AddAdministrator()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new Role(UserRoles.Administrator.ToString(), "Role Seed For Security Default");
                var adminRoleInDb = await _roleManager.FindByNameAsync(UserRoles.Administrator.ToString());
                if (adminRoleInDb is null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    _logger.LogInformation("Seeded Administrator Role");
                }

                //Check if User Exists
                var superUser = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "0988043422",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    Status = true,
                    CreatedDate = DateTimeOffset.UtcNow
                };

                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);

                if (superUserInDb is null)
                {
                    await _userManager.CreateAsync(superUser, UserConstant.DefaultPasswordAmin);
                    var result = await _userManager.AddToRoleAsync(superUser, UserRoles.Administrator.ToString());
                    if (result.Succeeded)
                    {
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Users);
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Roles);
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.UserPermissions);
                    }

                    _logger.LogInformation("Seeded User with Administrator Role");
                }
            }).GetAwaiter().GetResult();
        }
        private void AddUser()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new Role(UserRoles.User.ToString(), "Role Seed For Security Default");
                var adminRoleInDb = await _roleManager.FindByNameAsync(UserRoles.User.ToString());
                if (adminRoleInDb is null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    _logger.LogInformation("Seeded User Role");
                }

                //Check if User Exists
                var superUser = new User
                {
                    FirstName = "USER",
                    LastName = "USER",
                    Email = "User@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    UserName = "USER",
                    NormalizedUserName = "USER",
                    PhoneNumber = "09824443422",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    Status = true,
                    CreatedDate = DateTimeOffset.UtcNow
                };

                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);

                if (superUserInDb is null)
                {
                    await _userManager.CreateAsync(superUser, UserConstant.DefaultPasswordUser);
                    var result = await _userManager.AddToRoleAsync(superUser, UserRoles.User.ToString());
                    if (result.Succeeded)
                    {
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModulesUser.Users);
                    }

                    _logger.LogInformation("Seeded User with User Role");
                }
            }).GetAwaiter().GetResult();
        }
    }
}
