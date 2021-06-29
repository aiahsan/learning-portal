using Learning.Portal.Controllers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Models
{
    public static class RoleIds
    {
        public const int Admin = 1;
        public const int Teacher = 3;
        public const int Parent = 2;
        public const int Student = 4;
    }
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Teacher = "Teacher";
        public const string Parent = "Parent";
        public const string Student = "Student";
    }
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LoggedInAt { get; set; }
        public User CreatedBy { get; set; }

    }
}
