using GroupProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMgr)
        {
            userManager = userMgr;
            roleManager = roleMgr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddAdmin()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("Admin");

            if(!x)
            {
                //Create the Role
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                //Create a user with Admin Powers
                var user = new ApplicationUser();
                user.UserName = "AdminUser@email.com";
                user.Email = "AdminUser@email.com";

                //Assign a password
                string userPWD = "Password@1234";

                //Create the User w/Password
                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if(chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");

                    ViewData["Message"] = "User and Role Created!";
                }
                else
                {
                    ViewData["Message"] = "Looks like something went wrong. Contact Admin.";
                }
            }
            else
            {
                ViewData["Message"] = "This role already exists!";
            }

            return View();
        }

        public async Task<IActionResult> AddModerator()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("Moderator");

            if (!x)
            {
                //Create Mod Role
                var role = new IdentityRole();
                role.Name = "Moderator";
                await roleManager.CreateAsync(role);

                //Create role with Mod powers
                var user = new ApplicationUser();
                user.UserName = "ModeratorUser@email.com";
                user.Email = "ModeratorUser@email.com";

                //Assign Password
                string userPWD = "Password@1234";

                //Create the user with the Password
                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if(chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Moderator");

                    ViewData["Message"] = "User and role Created!";
                }
                else
                {
                    ViewData["Message"] = "Looks like something went wrong. Contact Admin.";
                }
            }
            else
            {
                ViewData["Message"] = "This role already exists!";
            }

            return View();
        }
    }
}
