using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly IRegistros _registrosService;

        public RegistrosController(IRegistros registrosService)
        {
            _registrosService = registrosService;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
            var registros = await _registrosService.GetRegistrosAsync();
            return View(registros);
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var registro = await _registrosService.GetRegistroByIdAsync(id.Value);

            if (registro == null) return NotFound();

            return View(registro);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,CursoId,FechaInscripcion")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                await _registrosService.AddRegistroAsync(registro);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var registro = await _registrosService.GetRegistroByIdAsync(id.Value);
            if (registro == null) return NotFound();

            return View(registro);
        }

        // POST: Registros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CursoId,FechaInscripcion")] Registro registro)
        {
            if (id != registro.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _registrosService.UpdateRegistroAsync(registro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RegistroExists(registro.Id))
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
            return View(registro);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var registro = await _registrosService.GetRegistroByIdAsync(id.Value);
            if (registro == null) return NotFound();

            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _registrosService.DeleteRegistroAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RegistroExists(int id)
        {
            var registro = await _registrosService.GetRegistroByIdAsync(id);
            return registro != null;
        }
    }
}
