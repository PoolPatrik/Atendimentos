using Atendimentos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Controllers
{
    public class SistemasController : Controller
    {
        private readonly SistemaServico _sistemaServico;

        public SistemasController(SistemaServico sistemaServico)
        {
            _sistemaServico = sistemaServico;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _sistemaServico.ListarTudosAsync();
            return View(list);
        }
    }
}
