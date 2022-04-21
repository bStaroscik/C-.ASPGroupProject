using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GroupProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly GroupProjectContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductsController(GroupProjectContext context, IHostingEnvironment hostEnv)
        {
            _context = context;
            hostingEnvironment = hostEnv;
        }

        // GET: Products
        //public async Task<IActionResult> Index()
        //{

        //    return View(await _context.Product.ToListAsync());
        //}

        public ActionResult Index(string id)
        {
            string searchString = id;
            var products = from p in _context.Product
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductName,Price,ImageName,Category")] Product product)
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFilename = Guid.NewGuid() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newProduct = new Product
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    ImageName = uniqueFilename,
                    Category = model.Category
                };

                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ProductName,Price,ImageName,Category")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int? id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        public IActionResult AddToCart(int? id, string returnUrl)
        {
            Product product = _context.Product.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);


            }

            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public IActionResult RemoveFromCart(int? id, string returnUrl)
        {
            Product product = _context.Product.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }

            return View("AddToCart", new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        //Call Update method from Cart class
      
        public IActionResult UpdateQuantity(int? id, string returnUrl, int quantity)
        {
            Product product = _context.Product.FirstOrDefault(p => p.Id == id);
             
            if (product != null)
            {
                Cart cart = GetCart();
                cart.UpdateItem(product, quantity);
                SaveCart(cart);

            }

            return View("AddToCart", new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }


    

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetObject("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            return cart;
        }
    }
}
