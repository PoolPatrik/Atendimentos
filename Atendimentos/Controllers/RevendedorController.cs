using Atendimentos.Models;
using Atendimentos.Models.ViewModels;
using Atendimentos.Services;
using Atendimentos.Services.Exeption;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Controllers
{
    public class RevendedorController : Controller
    {
        private readonly RevendedorServico _revendedorServico;

        public RevendedorController(RevendedorServico revendedorServico)
        {
            _revendedorServico = revendedorServico;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _revendedorServico.ListarTudosAsync();
            return View(list);
        }

        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(Revendedor revendedor)
        {
            if (!ModelState.IsValid)
            {
                return View(revendedor);
            }
            await _revendedorServico.IncluirAsync(revendedor);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                await _revendedorServico.ApagarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Apagar(int? id) //parametro opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Objeto não encontrado" });
            }
            var obj = await _revendedorServico.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Objeto não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada" });
            }

            var obj = await _revendedorServico.BuscaPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Revendedor revendedor)
        {
            if (!ModelState.IsValid)
            {
                return View(revendedor);
            }

            if (id != revendedor.Id)
            {

                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada BadRequest" });
            }

            await _revendedorServico.EditarAsync(revendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

