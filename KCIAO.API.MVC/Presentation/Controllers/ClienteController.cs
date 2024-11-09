using Microsoft.AspNetCore.Mvc;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClienteController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        // GET: Cliente
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientesEntities = _clienteApplicationService.ObterTodosClientes();

            var clientes = clientesEntities?.Select(cliente => new ClienteEditDto
            {
                id_cliente = cliente.id_cliente,
                nm_cliente = cliente.nm_cliente
                // outros campos, se necessário
            }).ToList() ?? new List<ClienteEditDto>(); // Retorna uma lista vazia se `clientesEntities` for null

            return View(clientes);
        }

        // GET: Cliente/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var cliente = _clienteApplicationService.ObterClienteporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_cliente,nm_cliente")] ClienteDto model)
        {
            if (ModelState.IsValid)
            {
                _clienteApplicationService.SalvarDadosCliente(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Cliente/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var cliente = _clienteApplicationService.ObterClienteporId(id ?? "");

            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(new ClienteEditDto
            {
                id_cliente = cliente.id_cliente,
                nm_cliente = cliente.nm_cliente
            });
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id_cliente,nm_cliente")] ClienteEditDto cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteApplicationService.EditarDadosCliente(id, cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = _clienteApplicationService.ObterClienteporId(id ?? "");


            if (id == "" || id == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = _clienteApplicationService.DeletarDadosCliente(id);

            if (cliente != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }
    }
}
