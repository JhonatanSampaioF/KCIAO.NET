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
    public class ConsultaController : Controller
    {
        private readonly ApplicationContext _context;

        public ConsultaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consulta.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta
                .FirstOrDefaultAsync(m => m.id_consulta == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_consulta,profissional,local_consulta,horario_consulta")] ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultaModel);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta.FindAsync(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            return View(consultaModel);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_consulta,profissional,local_consulta,horario_consulta")] ConsultaModel consultaModel)
        {
            if (id != consultaModel.id_consulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaModelExists(consultaModel.id_consulta))
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
            return View(consultaModel);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta
                .FirstOrDefaultAsync(m => m.id_consulta == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultaModel = await _context.Consulta.FindAsync(id);
            if (consultaModel != null)
            {
                _context.Consulta.Remove(consultaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaModelExists(string id)
        {
            return _context.Consulta.Any(e => e.id_consulta == id);
        }
    }
}
