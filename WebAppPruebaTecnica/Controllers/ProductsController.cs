using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPruebaTecnica.Entities;
using WebAppPruebaTecnica.Models;

namespace WebAppPruebaTecnica.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly SalesDbContext _context;

        public ProductsController(SalesDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            List<ProductViewModel> viewModel = await _context.Products.Select(x => new ProductViewModel() {
                Id= x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                Price = x.Price,
                Picture = x.Picture,
                ProviderId = x.ProviderId,
                Code = x.Code
            }).ToListAsync();

            return View(viewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                CreationDate = product.CreationDate,
                Price = product.Price, 
                Picture = product.Picture,  
                ProviderId = product.ProviderId,
                Code= product.Code
            };

            return View(viewModel);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            List<Provider> providers = await _context.Providers.ToListAsync();

            ProductViewModel viewModel = new ProductViewModel()
            {
                Providers = providers
            };


            return View(viewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel.Providers = await _context.Providers.ToListAsync();

            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = productViewModel.Name,
                    CreationDate = DateTime.Now,
                    Price = productViewModel.Price,
                    Picture = productViewModel.Picture,
                    ProviderId = productViewModel.ProviderId,
                    Code = productViewModel.Code
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            List<Provider> providers = await _context.Providers.ToListAsync();

            ProductViewModel viewModel = new ProductViewModel()
            {
                Name = product.Name,
                CreationDate = product.CreationDate,
                Price = product.Price,
                Picture = product.Picture,
                ProviderId = product.ProviderId,
                Providers = providers,
                Code = product.Code
            };

            return View(viewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return NotFound();
            }

            productViewModel.Providers = await _context.Providers.ToListAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new Product()
                    {
                        Id = productViewModel.Id,
                        Name = productViewModel.Name,
                        Price = productViewModel.Price,
                        Picture = productViewModel.Picture,
                        ProviderId = productViewModel.ProviderId,
                        Code = productViewModel.Code
                    };

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productViewModel.Id))
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
            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }


            ProductViewModel viewModel = new ProductViewModel()
            {
                Name = product.Name,
                CreationDate = product.CreationDate,
                Price = product.Price,
                Picture = product.Picture,
                ProviderId = product.ProviderId,
                Code= product.Code,
                Providers = await _context.Providers.ToListAsync()
        };

            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
