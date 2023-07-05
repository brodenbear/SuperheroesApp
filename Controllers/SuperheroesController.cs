using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            if (ModelState.IsValid)
            {
                Superhero newSuperhero = new Superhero
                {
                    Name = superhero.Name,
                    PrimaryAbility = superhero.PrimaryAbility,
                    SecondaryAbility = superhero.SecondaryAbility,
                    AlterEgo = superhero.AlterEgo,
                    Catchphrase = superhero.Catchphrase,
                };

                _context.Superheroes.Add(newSuperhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(superhero);
        }
    

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingSuperhero = _context.Superheroes.Find(id);
                    if (existingSuperhero == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existingSuperhero entity based on the submitted form data
                    existingSuperhero.Name = superhero.Name;
                    existingSuperhero.PrimaryAbility = superhero.PrimaryAbility;
                    existingSuperhero.SecondaryAbility = superhero.SecondaryAbility;
                    existingSuperhero.AlterEgo = superhero.AlterEgo;
                    existingSuperhero.Catchphrase = superhero.Catchphrase;

                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View(superhero);
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
