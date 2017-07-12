using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Model;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class VegetablesController : Controller
    {
        private readonly TestAppContext _context;

        public VegetablesController(TestAppContext context)
        {
            _context = context;    
        }

        // GET: Vegetables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vegetables.ToListAsync());
        }

        // GET: Vegetables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetables = await _context.Vegetables
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vegetables == null)
            {
                return NotFound();
            }

            return View(vegetables);
        }

        // GET: Vegetables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produkt,Antal,Enhet,Medelande")] Vegetables vegetables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegetables);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vegetables);
        }

        // GET: Vegetables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetables = await _context.Vegetables.SingleOrDefaultAsync(m => m.Id == id);
            if (vegetables == null)
            {
                return NotFound();
            }
            return View(vegetables);
        }

        // POST: Vegetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Produkt,Antal,Enhet,Medelande")] Vegetables vegetables)
        {
            if (id != vegetables.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegetables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegetablesExists(vegetables.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(vegetables);
        }

        // GET: Vegetables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetables = await _context.Vegetables
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vegetables == null)
            {
                return NotFound();
            }

            return View(vegetables);
        }

        // POST: Vegetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vegetables = await _context.Vegetables.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vegetables.Remove(vegetables);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VegetablesExists(int id)
        {
            return _context.Vegetables.Any(e => e.Id == id);
        }
    }
}
