using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrial11.Data;
using ProjectTrial11.Models;
using System.Diagnostics;

namespace ProjectTrial11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult News()
        {
            List<News> news = _context.News.ToList();
            return View(news);
        }
        public IActionResult Contact()
        {
            return View();
        }

        [Authorize(Policy = "RequireEmailAdmin")]
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Abilities()
        {
            List<Ability> abilities = _context.Ability.ToList();
            return View(abilities);
        }
        public IActionResult Natures()
        {
            List<Nature> natures = _context.Nature.ToList();
            return View(natures);
        }
        public IActionResult Items()
        {
            List<Item> items = _context.Item.ToList();
            return View(items);
        }
        public IActionResult Moves()
        {
            List<Move> moves = _context.Move.ToList();
            return View(moves);
        }
        public IActionResult Locations()
        {
            {
                // Fetch data from Location and include related Cobblemons
                var locationsWithCobblemons = _context.Location
                    .Include(l => l.CobblemonLocations)
                    .ThenInclude(cl => cl.Cobblemon)
                    .ToList();

                return View(locationsWithCobblemons);
            }
        }
        public IActionResult CobblemonList()
        {
            {
                var statsWithCobblemons = _context.BaseStat
                    .Include(l => l.CobblemonBaseStats)
                    .ThenInclude(cl=>cl.Cobblemon)
                    .ToList();
                return View(statsWithCobblemons);
            }
        }

        public IActionResult Index()
        {
            List<Cobblemon> cobblemons = _context.Cobblemon.ToList();
            return View(cobblemons);
        }
        public IActionResult Cobbledex()
        {
            List<Cobblemon> cobblemons = _context.Cobblemon.ToList();
            return View(cobblemons);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}