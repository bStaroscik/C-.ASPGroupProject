using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class CustomerController : Controller
    {

            private readonly GroupProjectContext _context;
           


            public CustomerController(GroupProjectContext context)
            {
                _context = context;
                
            }
            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                

                Customer newCustomer = new Customer
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address=model.Address,
                    Email=model.Email
                };

                _context.Add(newCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



    }
}
