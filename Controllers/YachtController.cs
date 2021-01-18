using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAW_Yacht.Models;

namespace DAW_Yacht.Controllers
{
    public class YachtController : Controller
    {
        private readonly ModelsContext _context;

        public YachtController(ModelsContext context)
        {
            _context = context;
        }

        // GET: Yacht
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yachts.ToListAsync());
        }

        public async Task<IActionResult> Find()
        {
            DateTime DateStart = DateTime.Parse(Request.Query["DateStart"]);
            DateTime DateEnd = DateTime.Parse(Request.Query["DateEnd"]);
            var yachts = await _context.Yachts
                .Include(y => y.BookingModels)
                .Where(
                    y => !y.BookingModels.Any(
                        b => (
                                DateEnd > b.DateStart && DateStart < b.DateEnd
                            )
                    )
            ).ToListAsync();
            return View(yachts);
        }

        // GET: Yacht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yachtModel = await _context.Yachts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yachtModel == null)
            {
                return NotFound();
            }

            return View(yachtModel);
        }

        // GET: Yacht/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yacht/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Length,Rooms,Capacity,BasePrice")] YachtModel yachtModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yachtModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yachtModel);
        }

        // GET: Yacht/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yachtModel = await _context.Yachts.FindAsync(id);
            if (yachtModel == null)
            {
                return NotFound();
            }
            return View(yachtModel);
        }

        // POST: Yacht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Length,Rooms,Capacity,BasePrice")] YachtModel yachtModel)
        {
            if (id != yachtModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yachtModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YachtModelExists(yachtModel.Id))
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
            return View(yachtModel);
        }

        // GET: Yacht/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yachtModel = await _context.Yachts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yachtModel == null)
            {
                return NotFound();
            }

            return View(yachtModel);
        }

        // POST: Yacht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yachtModel = await _context.Yachts.FindAsync(id);
            _context.Yachts.Remove(yachtModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YachtModelExists(int id)
        {
            return _context.Yachts.Any(e => e.Id == id);
        }
    }
}



