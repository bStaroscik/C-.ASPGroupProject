using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
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
                return RedirectToAction(nameof(Details));
            }
            return View(model);
        }



    }
}
