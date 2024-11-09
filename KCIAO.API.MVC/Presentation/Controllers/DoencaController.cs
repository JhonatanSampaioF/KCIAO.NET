using Microsoft.AspNetCore.Mvc;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Presentation.Controllers
{
    public class DoencaController : Controller
    {
        private readonly IDoencaApplicationService _doencaApplicationService;

        public DoencaController(IDoencaApplicationService doencaApplicationService)
        {
            _doencaApplicationService = doencaApplicationService;
        }

        // GET: Doenca
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doencasEntities = _doencaApplicationService.ObterTodasDoencas();

            var doencas = doencasEntities?.Select(doenca => new DoencaEditDto
            {
                id_doenca = doenca.id_doenca,
                nm_doenca = doenca.nm_doenca
                // outros campos, se necessário
            }).ToList() ?? new List<DoencaEditDto>(); // Retorna uma lista vazia se `doencasEntities` for null

            return View(doencas);
        }

        // GET: Doenca/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var doenca = _doencaApplicationService.ObterDoencaporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(doenca);
        }

        // GET: Doenca/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doenca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_doenca,nm_doenca")] DoencaDto model)
        {
            if (ModelState.IsValid)
            {
                _doencaApplicationService.SalvarDadosDoenca(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Doenca/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var doenca = _doencaApplicationService.ObterDoencaporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(new DoencaEditDto
            {
                id_doenca = doenca.id_doenca,
                nm_doenca = doenca.nm_doenca
            });
        }

        // POST: Doenca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_doenca,nm_doenca")] DoencaEditDto doenca)
        {
            if (ModelState.IsValid)
            {
                _doencaApplicationService.EditarDadosDoenca(id, doenca);
                return RedirectToAction(nameof(Index));
            }
            return View(doenca);
        }

        // GET: Doenca/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var doenca = _doencaApplicationService.ObterDoencaporId(id ?? "");


            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(doenca);
        }

        // POST: Doenca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doenca = _doencaApplicationService.DeletarDadosDoenca(id);

            if (doenca != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(doenca);
        }
    }
}
