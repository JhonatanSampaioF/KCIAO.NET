using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KCIAO.API.MVC.Models;
using KCIAO.API.MVC.Infraestructure.Data.AppData;

namespace KCIAO.API.MVC.Presentation.Controllers
{
    public class EventoController : Controller
    {
        private readonly ApplicationContext _context;

        public EventoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoModel = await _context.Evento
                .FirstOrDefaultAsync(m => m.id_evento == id);
            if (eventoModel == null)
            {
                return NotFound();
            }

            return View(eventoModel);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_evento,tipo_evento,desc_evento,dt_evento")] EventoModel eventoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventoModel);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoModel = await _context.Evento.FindAsync(id);
            if (eventoModel == null)
            {
                return NotFound();
            }
            return View(eventoModel);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_evento,tipo_evento,desc_evento,dt_evento")] EventoModel eventoModel)
        {
            if (id != eventoModel.id_evento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoModelExists(eventoModel.id_evento))
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
            return View(eventoModel);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoModel = await _context.Evento
                .FirstOrDefaultAsync(m => m.id_evento == id);
            if (eventoModel == null)
            {
                return NotFound();
            }

            return View(eventoModel);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var eventoModel = await _context.Evento.FindAsync(id);
            if (eventoModel != null)
            {
                _context.Evento.Remove(eventoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoModelExists(string id)
        {
            return _context.Evento.Any(e => e.id_evento == id);
        }
    }
}
