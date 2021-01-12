using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAW_Yacht.Models;

namespace DAW_Yacht.Controllers
{
    public class VolumController : Controller
    {
        private readonly ModelsContext _context;

        public VolumController(ModelsContext context)
        {
            _context = context;
        }

        // GET: Volum
        public async Task<IActionResult> Index()
        {
            return View(await _context.Volume.ToListAsync());
        }

        // GET: Volum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumModel = await _context.Volume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volumModel == null)
            {
                return NotFound();
            }

            return View(volumModel);
        }

        // GET: Volum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Denumire")] VolumModel volumModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volumModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volumModel);
        }

        // GET: Volum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumModel = await _context.Volume.FindAsync(id);
            if (volumModel == null)
            {
                return NotFound();
            }
            return View(volumModel);
        }

        // POST: Volum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denumire")] VolumModel volumModel)
        {
            if (id != volumModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volumModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolumModelExists(volumModel.Id))
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
            return View(volumModel);
        }

        // GET: Volum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volumModel = await _context.Volume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volumModel == null)
            {
                return NotFound();
            }

            return View(volumModel);
        }

        // POST: Volum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volumModel = await _context.Volume.FindAsync(id);
            _context.Volume.Remove(volumModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolumModelExists(int id)
        {
            return _context.Volume.Any(e => e.Id == id);
        }
    }
}
