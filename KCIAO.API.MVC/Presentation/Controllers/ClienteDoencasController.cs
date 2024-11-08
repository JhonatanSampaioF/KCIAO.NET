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
    public class ClienteDoencasController : Controller
    {
        private readonly ApplicationContext _context;

        public ClienteDoencasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ClienteDoencas
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ClienteDoenca.Include(c => c.Cliente).Include(c => c.Doenca);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ClienteDoencas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDoenca = await _context.ClienteDoenca
                .Include(c => c.Cliente)
                .Include(c => c.Doenca)
                .FirstOrDefaultAsync(m => m.fk_cliente == id);
            if (clienteDoenca == null)
            {
                return NotFound();
            }

            return View(clienteDoenca);
        }

        // GET: ClienteDoencas/Create
        public IActionResult Create()
        {
            ViewData["fk_cliente"] = new SelectList(_context.Cliente, "id_cliente", "id_cliente");
            ViewData["fk_doenca"] = new SelectList(_context.Doenca, "id_doenca", "id_doenca");
            return View();
        }

        // POST: ClienteDoencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fk_cliente,fk_doenca")] ClienteDoenca clienteDoenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteDoenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fk_cliente"] = new SelectList(_context.Cliente, "id_cliente", "id_cliente", clienteDoenca.fk_cliente);
            ViewData["fk_doenca"] = new SelectList(_context.Doenca, "id_doenca", "id_doenca", clienteDoenca.fk_doenca);
            return View(clienteDoenca);
        }

        // GET: ClienteDoencas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDoenca = await _context.ClienteDoenca.FindAsync(id);
            if (clienteDoenca == null)
            {
                return NotFound();
            }
            ViewData["fk_cliente"] = new SelectList(_context.Cliente, "id_cliente", "id_cliente", clienteDoenca.fk_cliente);
            ViewData["fk_doenca"] = new SelectList(_context.Doenca, "id_doenca", "id_doenca", clienteDoenca.fk_doenca);
            return View(clienteDoenca);
        }

        // POST: ClienteDoencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("fk_cliente,fk_doenca")] ClienteDoenca clienteDoenca)
        {
            if (id != clienteDoenca.fk_cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteDoenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteDoencaExists(clienteDoenca.fk_cliente))
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
            ViewData["fk_cliente"] = new SelectList(_context.Cliente, "id_cliente", "id_cliente", clienteDoenca.fk_cliente);
            ViewData["fk_doenca"] = new SelectList(_context.Doenca, "id_doenca", "id_doenca", clienteDoenca.fk_doenca);
            return View(clienteDoenca);
        }

        // GET: ClienteDoencas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteDoenca = await _context.ClienteDoenca
                .Include(c => c.Cliente)
                .Include(c => c.Doenca)
                .FirstOrDefaultAsync(m => m.fk_cliente == id);
            if (clienteDoenca == null)
            {
                return NotFound();
            }

            return View(clienteDoenca);
        }

        // POST: ClienteDoencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var clienteDoenca = await _context.ClienteDoenca.FindAsync(id);
            if (clienteDoenca != null)
            {
                _context.ClienteDoenca.Remove(clienteDoenca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteDoencaExists(string id)
        {
            return _context.ClienteDoenca.Any(e => e.fk_cliente == id);
        }
    }
}
