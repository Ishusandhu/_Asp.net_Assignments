using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ishu_Bowl.Data;
using Ishu_Bowl.Models;

namespace Ishu_Bowl.Controllers
{
    public class BowlsController : Controller
    {
        private readonly BowlContext _context;

        public BowlsController(BowlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string selectedbowlMaterial, string searchString)
        {
            // Use LINQ to get a list of distinct materials.
            IQueryable<string> materialQuery = from b in _context.Bowl
                                               orderby b.Material
                                               select b.Material;

            var bowls = from b in _context.Bowl
                        select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                bowls = bowls.Where(b => b.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(selectedbowlMaterial))
            {
                bowls = bowls.Where(b => b.Material == selectedbowlMaterial);
            }

            var selectedbowlMaterialVM = new BowlMaterialViewModel
            {
               BowlMaterials = new SelectList(await materialQuery.Distinct().ToListAsync()),
                Bowls = await bowls.ToListAsync()
            };

            return View(selectedbowlMaterialVM);
        }



        // GET: Bowls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bowl == null)
            {
                return NotFound();
            }

            return View(bowl);
        }

        // GET: Bowls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateCreated,Material,Price,MicrowaveSafe,Depth,Rating")] Bowl bowl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowl);
        }

        // GET: Bowls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl.FindAsync(id);
            if (bowl == null)
            {
                return NotFound();
            }
            return View(bowl);
        }

        // POST: Bowls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateCreated,Material,Price,MicrowaveSafe,Depth,Rating")] Bowl bowl)
        {
            if (id != bowl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlExists(bowl.Id))
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
            return View(bowl);
        }

        // GET: Bowls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bowl == null)
            {
                return NotFound();
            }

            return View(bowl);
        }

        // POST: Bowls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowl = await _context.Bowl.FindAsync(id);
            _context.Bowl.Remove(bowl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlExists(int id)
        {
            return _context.Bowl.Any(e => e.Id == id);
        }
    }
}
