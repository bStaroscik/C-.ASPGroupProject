//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GroupProject.Data;

//namespace GroupProject.Controllers
//{
//    public class ManageUsersController : Controller
//    {
//        {
//            private Data.GroupProjectContext _context;

//        public ManageUsersController(GroupProjectContext context, )
//        {
//            _context = ContextBoundObject;
//        }

//        public ActionResult UsersWithRoles()
//        {
//            var usersWithRoles = (from user in context.Users
//                                  select new
//                                  {
//                                      UserId = user.Id,
//                                      Username = user.UserName,
//                                      Email = user.Email,
//                                      RoleNames = (from userRole in user.Roles
//                                                   join role in context.Roles on userRole.RoleId
//                                                   equals role.Id
//                                                   select role.Name).ToList()
//                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

//                                  {
//                                      UserId = p.UserId,
//                                      Username = p.Username,
//                                      Email = p.Email,
//                                      Role = string.Join(",", p.RoleNames)
//                                  });


//            return View(usersWithRoles);
//        }
//    }
