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
    public class AtendimentosController : Controller
    {
        private readonly AtendimentoServico _atendimentoServico;
        private readonly SistemaServico _sistemaServico;
        private readonly RevendedorServico _revendedorServico;
        private readonly UsuarioServico _usuarioServico;

        public AtendimentosController(AtendimentoServico atendimentoServico, SistemaServico sistemaServico, RevendedorServico revendedorServico, UsuarioServico usuarioServico)
        {
            _atendimentoServico = atendimentoServico;
            _sistemaServico = sistemaServico;
            _revendedorServico = revendedorServico;
            _usuarioServico = usuarioServico;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _atendimentoServico.ListarTudosAsync();
            return View(list);
        }

        public async Task<IActionResult> Incluir()
        {
            var sistemas = await _sistemaServico.ListarTudosAsync();
            var revendedores = await _revendedorServico.ListarTudosAsync();
            var usuarios = await _usuarioServico.ListarTudosAsync();

            var viewModel = new AtendimentoViewModel { Sistemas = sistemas, Revendedores = revendedores, Usuarios = usuarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(Atendimento atendimento)
        {
            if (!ModelState.IsValid)
            {
                var sistemas = await _sistemaServico.ListarTudosAsync();
                var revendedores = await _revendedorServico.ListarTudosAsync();
                var usuarios = await _usuarioServico.ListarTudosAsync();

                var viewModel = new AtendimentoViewModel {Atendimento = atendimento, Sistemas = sistemas, Revendedores = revendedores, Usuarios = usuarios };
                return View(viewModel);
            }
            await _atendimentoServico.IncluirAsync(atendimento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Apagar(int? id) //parametro opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Objeto não encontrado" });
            }
            var obj = await _atendimentoServico.BuscaPorIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Objeto não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                await _atendimentoServico.ApagarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada" });
            }

            var obj = await _atendimentoServico.BuscaPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada" });
            }

            var sistemas = await _sistemaServico.ListarTudosAsync();
            var revendedores = await _revendedorServico.ListarTudosAsync();
            var usuarios = await _usuarioServico.ListarTudosAsync();

            var viewModel = new AtendimentoViewModel { Atendimento = obj, Sistemas = sistemas, Revendedores = revendedores, Usuarios = usuarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Atendimento atendimento)
        {
            if (!ModelState.IsValid)
            {
                var sistemas = await _sistemaServico.ListarTudosAsync();
                var revendedores = await _revendedorServico.ListarTudosAsync();
                var usuarios = await _usuarioServico.ListarTudosAsync();

                var viewModel = new AtendimentoViewModel { Atendimento = atendimento, Sistemas = sistemas, Revendedores = revendedores, Usuarios = usuarios };
                return View(viewModel);
            }

            if (id != atendimento.Id)
            {

                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada BadRequest" });
            }

            await _atendimentoServico.EditarAsync(atendimento);
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

