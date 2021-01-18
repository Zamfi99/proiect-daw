using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAW_Yacht.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Ocsp;

namespace DAW_Yacht.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YachtController : Controller
    {
        private readonly ModelsContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public YachtController(ModelsContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Yacht
        public async Task<IActionResult> Index()
        {
            var modelsContext = _context.Yachts.Include(y => y.Gallery);
            return View(await modelsContext.ToListAsync());
        }

        // GET: Yacht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yachtModel = await _context.Yachts
                .Include(y => y.Gallery)
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
            ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Name");
            return View();
        }

        // POST: Yacht/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Length,Rooms,Capacity,BasePrice,GalleryId")] YachtModel yachtModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yachtModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Name", yachtModel.GalleryId);
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
            ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Name", yachtModel.GalleryId);
            return View(yachtModel);
        }

        // POST: Yacht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Length,Rooms,Capacity,BasePrice,GalleryId")] YachtModel yachtModel)
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
            ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Name", yachtModel.GalleryId);
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
                .Include(y => y.Gallery)
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
        
        [AllowAnonymous]
        public async Task<IActionResult> Find()
        {
            DateTime DateStart = DateTime.Parse(Request.Query["DateStart"]);
            DateTime DateEnd = DateTime.Parse(Request.Query["DateEnd"]);
            var yachts = await _context.Yachts
                .Include(y => y.BookingModels)
                .Include(y => y.Gallery)
                .Include(y => y.Gallery.ImageModels)
                .Where(
                    y => !y.BookingModels.Any(
                        b => (
                            DateEnd > b.DateStart && DateStart < b.DateEnd
                        )
                    )
                ).ToListAsync();
            ViewBag.DateStart = DateStart;
            ViewBag.DateEnd = DateEnd;
            return View(yachts);
        }
        
        [Authorize(Roles = "Admin,Guest")]
        [HttpPost]
        public async Task<IActionResult> Book()
        {
            int YachtId = Int32.Parse(Request.Form["YachtId"]);
            DateTime DateStart = DateTime.Parse(Request.Form["DateStart"]);
            DateTime DateEnd = DateTime.Parse(Request.Form["DateEnd"]);
            var prices = await _context.Price.Where(
                p => p.DateStart <= DateStart && p.DateEnd >= DateStart &&
                     p.DateStart <= DateEnd && p.DateEnd >= DateEnd
            ).FirstOrDefaultAsync();
            var yacht = await _context.Yachts.Where(y => y.Id == YachtId).FirstOrDefaultAsync();
            var days = Math.Abs(DateEnd.Subtract(DateStart).Days);
            var booking = new BookingModel();
            booking.Price = yacht.BasePrice * (100 + prices.Grow) / 100 * days;
            booking.User = await _userManager.GetUserAsync(User);
            booking.Yacht = yacht;
            booking.DateStart = DateStart;
            booking.DateEnd = DateEnd;
            _context.Attach(booking).State = EntityState.Added;
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
