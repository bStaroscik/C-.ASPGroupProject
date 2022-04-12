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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
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
                    Address = model.Address,
                    Email = model.Email
                };

                _context.Add(newCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,FirstName,LastName,Address,Email")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
        public IActionResult CreateReview()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(Review model)
        {
            if (ModelState.IsValid)
            {


                Review newReview = new Review
                {
                    User = model.User,
                    ReviewText = model.ReviewText,
                    Rating = model.Rating
                };

                _context.Add(newReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);


        }
    }
}
