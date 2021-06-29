using Learning.Portal.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Context
{
    public class DbInitilizer
    {
        public static void CreateDatabase(LearningDbContext db)
        {
            db.Database.EnsureCreated();
        }

        public static async Task Init(UserManager<User> _userManager, RoleManager<IdentityRole<int>> _roleManager, LearningDbContext _learningDbContext)
        {
            if (!_roleManager.Roles.Any(x => x.Id == RoleIds.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>()
                {
                    Id = RoleIds.Admin,
                    Name = Role.Admin
                });
            }
            if (!_roleManager.Roles.Any(x => x.Id == RoleIds.Parent))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>()
                {
                    Id = RoleIds.Parent,
                    Name = Role.Parent
                });
            }
            if (!_roleManager.Roles.Any(x => x.Id == RoleIds.Teacher))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>()
                {
                    Id = RoleIds.Teacher,
                    Name = Role.Teacher
                });
            }
            if (!_roleManager.Roles.Any(x => x.Id == RoleIds.Student))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>()
                {
                    Id = RoleIds.Student,
                    Name = Role.Student
                });
            }
            if (!_userManager.Users.Any(x => x.UserName == "super"))
            {
                var user = new User()
                {
                    Id = 1,
                    UserName = "super",
                    Email = "admin@learningportal.com",
                    IsActive = true,
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(user, "Super123!@#");

                await _userManager.AddToRoleAsync(user, Role.Admin);
            }
            //for (int i = 1; i <= 10; i++)
            //{
            //    string title = $"Class-{i}";
            //    if (!_learningDbContext.Classes.Any(x => x.Title == title))
            //    {
            //        _learningDbContext.Classes.Add(new Class()
            //        {
            //            Title = title,
            //            Description = title,
            //            CreatedAt = DateTime.UtcNow
            //        });
            //    }
            //}
            //_learningDbContext.SaveChanges();
        }
    }
}
