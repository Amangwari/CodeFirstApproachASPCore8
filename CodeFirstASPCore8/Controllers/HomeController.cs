using System.Diagnostics;
using CodeFirstASPCore8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstASPCore8.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        //to make a constructor shortcutkey is ctor

        private readonly StudentDbContext studentDb;
        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDb.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDb.Students.AddAsync(std);
                await studentDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || studentDb.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if(stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDb.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDb.Students.FindAsync(id);
            await studentDb.Students.ExecuteUpdateAsync(stdData);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
