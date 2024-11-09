using Microsoft.AspNetCore.Mvc;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;
using KCIAO.API.MVC.Application.Services;

namespace KCIAO.API.MVC.Presentation.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaApplicationService _consultaApplicationService;

        public ConsultaController(IConsultaApplicationService consultaApplicationService)
        {
            _consultaApplicationService = consultaApplicationService;
        }

        // GET: Consulta
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var consultasEntities = _consultaApplicationService.ObterTodasConsultas();

            var consultas = consultasEntities?.Select(consulta => new ConsultaEditDto
            {
                id_consulta = consulta.id_consulta,
                profissional = consulta.profissional,
                local_consulta = consulta.local_consulta,
                horario_consulta = consulta.horario_consulta,
                fk_evento = consulta.fk_evento
                // outros campos, se necessário
            }).ToList() ?? new List<ConsultaEditDto>(); // Retorna uma lista vazia se `consultasEntities` for null

            return View(consultas);
        }

        // GET: Consulta/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var consulta = _consultaApplicationService.ObterConsultaporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_consulta,profissional,local_consulta,horario_consulta")] ConsultaDto model)
        {
            if (ModelState.IsValid)
            {
                _consultaApplicationService.SalvarDadosConsulta(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Consulta/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var consulta = _consultaApplicationService.ObterConsultaporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(new ConsultaEditDto
            {
                id_consulta = consulta.id_consulta,
                profissional = consulta.profissional,
                local_consulta = consulta.local_consulta,
                horario_consulta = consulta.horario_consulta,
                fk_evento = consulta.fk_evento
            });
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_consulta,profissional,local_consulta,horario_consulta")] ConsultaEditDto consulta)
        {
            if (ModelState.IsValid)
            {
                _consultaApplicationService.EditarDadosConsulta(id, consulta);
                return RedirectToAction(nameof(Index));
            }
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var consulta = _consultaApplicationService.ObterConsultaporId(id ?? "");


            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consulta = _consultaApplicationService.DeletarDadosConsulta(id);

            if (consulta != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(consulta);
        }
    }
}
