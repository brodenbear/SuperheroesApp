using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroesApp.Data;
using SuperheroesApp.Models;

namespace SuperheroesApp.Controllers
{
    public class SuperheroesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;

        }
        // GET: SuperheroesController
        public ActionResult Index()
        {

            //LINQ query to retrieve all rows from table
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: SuperheroesController/Details/5
        public ActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // GET: SuperheroesController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SuperheroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
