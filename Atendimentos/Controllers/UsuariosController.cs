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
    public class UsuariosController : Controller
    {
        private readonly UsuarioServico _usuarioServico;

        public UsuariosController(UsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _usuarioServico.ListarTudosAsync();
            return View(list);
        }

        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            await _usuarioServico.IncluirAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                await _usuarioServico.ApagarAsync(id);
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
            var obj = await _usuarioServico.BuscaPorIdAsync(id.Value);

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

            var obj = await _usuarioServico.BuscaPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            if (id != usuario.Id)
            {

                return RedirectToAction(nameof(Error), new { message = "Mensagem personalizada BadRequest" });
            }

            await _usuarioServico.EditarAsync(usuario);
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

