using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPruebaTecnica.Entities;
using WebAppPruebaTecnica.Models;

namespace WebAppPruebaTecnica.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesDbContext _context;

        public SalesController(SalesDbContext context)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            _context = context;
        }

        // GET: Sales
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            List<SaleViewModel> viewModel = await _context.Sales.Select(x => new SaleViewModel()
            {
                Id = x.Id,
                DateSale = x.DateSale,
                TotalAmount = x.TotalAmount,
                Cantity = x.Cantity,
                ProductId = x.ProductId,
            }).ToListAsync();

            return View(viewModel);
        }

        // POST: Sales
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindByDate(DateTime? fechaInicio, DateTime? fechaFin)
        {
            List<SaleViewModel> viewModel = await _context.Sales.Where(x=> x.DateSale >= fechaInicio && x.DateSale <= fechaFin).Select(x => new SaleViewModel()
            {
                Id = x.Id,
                DateSale = x.DateSale,
                TotalAmount = x.TotalAmount,
                Cantity = x.Cantity,
                ProductId = x.ProductId,
            }).ToListAsync();

            return View(nameof(Index),viewModel);
        }

        // GET: Sales/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public async Task<IActionResult> Create()
        {
             List<Product> products  = await _context.Products.ToListAsync();
            SaleViewModel saleViewModel = new SaleViewModel() { Products = products };
            return View(saleViewModel);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleViewModel saleViewModel)
        {
            saleViewModel.Products = await _context.Products.ToListAsync(); 
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData)?.Value);

                Sale sale = new Sale()
                {
                    Id = saleViewModel.Id,
                    UserId = userId,
                    Cantity = saleViewModel.Cantity,
                    DateSale = saleViewModel.DateSale,
                    TaxValue = saleViewModel.TaxValue,
                    TotalAmount = saleViewModel.TotalAmount,
                    ProductId = saleViewModel.ProductId,
                };

                _context.Add(sale);
                await _context.SaveChangesAsync();
                ModelState.AddModelError(string.Empty, "Registro Creado Correctamente");
            }
            return View(saleViewModel);
        }

        // GET: Sales/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Product> products = await _context.Products.ToListAsync();
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            SaleViewModel saleViewModel = new SaleViewModel() { 
                Id=sale.Id, 
                UserId= sale.UserId, 
                Cantity= sale.Cantity,
                DateSale= sale.DateSale, 
                TaxValue = sale.TaxValue, 
                TotalAmount = sale.TotalAmount ,
                ProductId = sale.ProductId,
                Products = products 
            };

            return View(saleViewModel);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, SaleViewModel saleViewModel)
        {
            if (id != saleViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Sale sale = new Sale()
                    {
                        Id = saleViewModel.Id,
                        UserId = saleViewModel.UserId,
                        Cantity = saleViewModel.Cantity,
                        DateSale = saleViewModel.DateSale,
                        TaxValue = saleViewModel.TaxValue,
                        TotalAmount = saleViewModel.TotalAmount,
                        ProductId = saleViewModel.ProductId,
                    };
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(saleViewModel.Id))
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
            return View(saleViewModel);
        }

        // GET: Sales/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            SaleViewModel saleViewModel = new SaleViewModel()
            {
                Id = sale.Id,
                UserId = sale.UserId,
                Cantity = sale.Cantity,
                DateSale = sale.DateSale,
                TaxValue = sale.TaxValue,
                TotalAmount = sale.TotalAmount
            };

            return View(saleViewModel);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(SaleViewModel sale)
        {
            sale.Products = await _context.Products.ToListAsync();

            if (ModelState.IsValid)
            {
                sale.TotalAmount = sale.Cantity * (_context.Products.Where(x => x.Id == sale.ProductId).Select(y => y.Price).FirstOrDefault());
            }
            return View(nameof(Create),sale);
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
