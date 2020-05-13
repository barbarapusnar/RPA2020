using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreTest.Models;

namespace NetCoreTest.Controllers
{
    public class MvcMoviesController : Controller
    {
        private readonly MovieContext _context;

        public MvcMoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: MvcMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.MvcMovie.ToListAsync());
        }

        // GET: MvcMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcMovie = await _context.MvcMovie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcMovie == null)
            {
                return NotFound();
            }

            return View(mvcMovie);
        }

        // GET: MvcMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] MvcMovie mvcMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mvcMovie);
        }

        // GET: MvcMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcMovie = await _context.MvcMovie.FindAsync(id);
            if (mvcMovie == null)
            {
                return NotFound();
            }
            return View(mvcMovie);
        }

        // POST: MvcMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] MvcMovie mvcMovie)
        {
            if (id != mvcMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcMovieExists(mvcMovie.Id))
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
            return View(mvcMovie);
        }

        // GET: MvcMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcMovie = await _context.MvcMovie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcMovie == null)
            {
                return NotFound();
            }

            return View(mvcMovie);
        }

        // POST: MvcMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcMovie = await _context.MvcMovie.FindAsync(id);
            _context.MvcMovie.Remove(mvcMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcMovieExists(int id)
        {
            return _context.MvcMovie.Any(e => e.Id == id);
        }
    }
}
