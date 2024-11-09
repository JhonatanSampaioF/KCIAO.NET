using Microsoft.AspNetCore.Mvc;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Presentation.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoApplicationService _eventoApplicationService;

        public EventoController(IEventoApplicationService eventoApplicationService)
        {
            _eventoApplicationService = eventoApplicationService;
        }

        // GET: Evento
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eventosEntities = _eventoApplicationService.ObterTodasEventos();

            var eventos = eventosEntities?.Select(evento => new EventoEditDto
            {
                id_evento = evento.id_evento,
                tipo_evento = evento.tipo_evento,
                desc_evento = evento.desc_evento,
                dt_evento = evento.dt_evento,
                fk_cliente = evento.fk_cliente
                // outros campos, se necessário
            }).ToList() ?? new List<EventoEditDto>(); // Retorna uma lista vazia se `eventosEntities` for null

            return View(eventos);
        }

        // GET: Evento/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var evento = _eventoApplicationService.ObterEventoporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_evento,tipo_evento,desc_evento,dt_evento")] EventoDto model)
        {
            if (ModelState.IsValid)
            {
                _eventoApplicationService.SalvarDadosEvento(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Evento/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var evento = _eventoApplicationService.ObterEventoporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(new EventoEditDto
            {
                id_evento = evento.id_evento,
                tipo_evento = evento.tipo_evento,
                desc_evento = evento.desc_evento,
                dt_evento = evento.dt_evento,
                fk_cliente = evento.fk_cliente
            });
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_evento,tipo_evento,desc_evento,dt_evento")] EventoEditDto evento)
        {
            if (ModelState.IsValid)
            {
                _eventoApplicationService.EditarDadosEvento(id, evento);
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Evento/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var evento = _eventoApplicationService.ObterEventoporId(id ?? "");


            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var evento = _eventoApplicationService.DeletarDadosEvento(id);

            if (evento != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(evento);
        }
    }
}
