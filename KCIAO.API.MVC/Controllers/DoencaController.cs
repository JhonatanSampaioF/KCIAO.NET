using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KCIAO.API.MVC.AppData;
using KCIAO.API.MVC.Models;

namespace KCIAO.API.MVC.Controllers
{
    public class DoencaController : Controller
    {
        private readonly ApplicationContext _context;

        public DoencaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Doenca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doenca.ToListAsync());
        }

        // GET: Doenca/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doencaModel = await _context.Doenca
                .FirstOrDefaultAsync(m => m.id_doenca == id);
            if (doencaModel == null)
            {
                return NotFound();
            }

            return View(doencaModel);
        }

        // GET: Doenca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doenca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_doenca,nm_doenca")] DoencaModel doencaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doencaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doencaModel);
        }

        // GET: Doenca/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doencaModel = await _context.Doenca.FindAsync(id);
            if (doencaModel == null)
            {
                return NotFound();
            }
            return View(doencaModel);
        }

        // POST: Doenca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_doenca,nm_doenca")] DoencaModel doencaModel)
        {
            if (id != doencaModel.id_doenca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doencaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoencaModelExists(doencaModel.id_doenca))
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
            return View(doencaModel);
        }

        // GET: Doenca/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doencaModel = await _context.Doenca
                .FirstOrDefaultAsync(m => m.id_doenca == id);
            if (doencaModel == null)
            {
                return NotFound();
            }

            return View(doencaModel);
        }

        // POST: Doenca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doencaModel = await _context.Doenca.FindAsync(id);
            if (doencaModel != null)
            {
                _context.Doenca.Remove(doencaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoencaModelExists(string id)
        {
            return _context.Doenca.Any(e => e.id_doenca == id);
        }
    }
}
