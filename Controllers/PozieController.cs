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
    public class PozieController : Controller
    {
        private readonly ModelsContext _context;

        public PozieController(ModelsContext context)
        {
            _context = context;
        }

        // GET: Pozie
        public async Task<IActionResult> Index()
        {
            var modelsContext = _context.Poezii.Include(p => p.Volum);
            return View(await modelsContext.ToListAsync());
        }

        // GET: Pozie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozieModel = await _context.Poezii
                .Include(p => p.Volum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozieModel == null)
            {
                return NotFound();
            }

            return View(pozieModel);
        }

        // GET: Pozie/Create
        public IActionResult Create()
        {
            ViewData["VolumId"] = new SelectList(_context.Volume, "Id", "Denumire");
            return View();
        }

        // POST: Pozie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Autor,Titlu,Strofe,VolumId")] PozieModel pozieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VolumId"] = new SelectList(_context.Volume, "Id", "Denumire", pozieModel.VolumId);
            return View(pozieModel);
        }

        [Route("/Pozie/FilterPoezie/{pozie}")]
        public async Task<IActionResult> FilterPozie(string pozie)
        {
            var modelsContext = _context.Poezii
                .Where(p => p.Titlu.Contains(pozie))
                .Include(p => p.Volum);
            return View(await modelsContext.ToListAsync());
        }
        
        [Route("/Pozie/FilterVolum/{volum}")]
        public async Task<IActionResult> FilterVolum(string volum)
        {
            var modelsContext = _context.Poezii
                .Where(p => p.Volum.Denumire.Contains(volum))
                .Include(p => p.Volum);
            return View(await modelsContext.ToListAsync());
        }

        // GET: Pozie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozieModel = await _context.Poezii.FindAsync(id);
            if (pozieModel == null)
            {
                return NotFound();
            }
            ViewData["VolumId"] = new SelectList(_context.Volume, "Id", "Denumire", pozieModel.VolumId);
            return View(pozieModel);
        }

        // POST: Pozie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Autor,Titlu,Strofe,VolumId")] PozieModel pozieModel)
        {
            if (id != pozieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozieModelExists(pozieModel.Id))
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
            ViewData["VolumId"] = new SelectList(_context.Volume, "Id", "Denumire", pozieModel.VolumId);
            return View(pozieModel);
        }

        // GET: Pozie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozieModel = await _context.Poezii
                .Include(p => p.Volum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozieModel == null)
            {
                return NotFound();
            }

            return View(pozieModel);
        }

        // POST: Pozie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozieModel = await _context.Poezii.FindAsync(id);
            _context.Poezii.Remove(pozieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozieModelExists(int id)
        {
            return _context.Poezii.Any(e => e.Id == id);
        }
    }
}
