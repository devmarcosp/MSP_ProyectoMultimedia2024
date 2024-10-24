using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly IRegistros _repository;

        public RegistrosController(IRegistros repository)
        {
            _repository = repository;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        { 
            return View(await _repository.GetAllAsync());
        }

        public async Task<IActionResult> ListaRegistros()
        {
            return PartialView(await _repository.GetAllAsync());
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _repository.GetByIdAsync(id.Value);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_repository.GetCursos(), "Id", "Descripcion");
            ViewData["UsuarioId"] = new SelectList(_repository.GetUsuarios(), "Id", "Apellido");
            return View();
        }

        // POST: Registros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,CursoId,FechaInscripcion")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(registro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_repository.GetCursos(), "Id", "Descripcion", registro.CursoId);
            ViewData["UsuarioId"] = new SelectList(_repository.GetUsuarios(), "Id", "Apellido", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _repository.GetByIdAsync(id.Value);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_repository.GetCursos(), "Id", "Descripcion", registro.CursoId);
            ViewData["UsuarioId"] = new SelectList(_repository.GetUsuarios(), "Id", "Apellido", registro.UsuarioId);
            return View(registro);
        }

        // POST: Registros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CursoId,FechaInscripcion")] Registro registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(registro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.RegistroExists(registro.Id))
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
            ViewData["CursoId"] = new SelectList(_repository.GetCursos(), "Id", "Descripcion", registro.CursoId);
            ViewData["UsuarioId"] = new SelectList(_repository.GetUsuarios(), "Id", "Apellido", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _repository.GetByIdAsync(id.Value);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

