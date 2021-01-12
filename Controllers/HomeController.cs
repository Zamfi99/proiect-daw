using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAW_Yacht.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW_Yacht.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelsContext _context;

        public HomeController(ILogger<HomeController> logger, ModelsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> ShowSearch([Bind("TitluPozie, TitluVolum")] SearchModel searchModel)
        {
            var modelsContext = _context.Poezii
                .Where(p => p.Titlu.Contains(searchModel.TitluPozie))
                .Where(p => p.Volum.Denumire.Contains(searchModel.TitluVolum))
                .Include(p => p.Volum);
            return View(await modelsContext.ToListAsync());
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}