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
    public class GalleryController : Controller
    {
        private readonly ModelsContext _context;

        public GalleryController(ModelsContext context)
        {
            _context = context;
        }

        // GET: Gallery
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gallery.ToListAsync());
        }

        // GET: Gallery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryModel = await _context.Gallery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galleryModel == null)
            {
                return NotFound();
            }

            return View(galleryModel);
        }

        // GET: Gallery/Create
        public IActionResult Create()
        {
            var images = _context.Images;
            ViewBag.images = images;
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IdImages")] GalleryModel galleryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galleryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galleryModel);
        }

        // GET: Gallery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryModel = await _context.Gallery.FindAsync(id);
            if (galleryModel == null)
            {
                return NotFound();
            }
            return View(galleryModel);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GalleryModel galleryModel)
        {
            if (id != galleryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galleryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryModelExists(galleryModel.Id))
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
            return View(galleryModel);
        }

        // GET: Gallery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryModel = await _context.Gallery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galleryModel == null)
            {
                return NotFound();
            }

            return View(galleryModel);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galleryModel = await _context.Gallery.FindAsync(id);
            _context.Gallery.Remove(galleryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryModelExists(int id)
        {
            return _context.Gallery.Any(e => e.Id == id);
        }
    }
}
