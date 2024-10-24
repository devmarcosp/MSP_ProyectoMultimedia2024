using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Repositories;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class CategoriaCursosController : Controller
    {
        private readonly ICategoriaCurso _categoriaCursoRepository;

        public CategoriaCursosController(ICategoriaCurso categoriaCursoRepository)
        {
            _categoriaCursoRepository = categoriaCursoRepository;
        }

        // GET: CategoriaCursos
        public async Task<IActionResult> Index()
        {
           
            return View(await _categoriaCursoRepository.GetAll());
        }
        public async Task<IActionResult> ListaCategoriaCursos()
        {

            return View(await _categoriaCursoRepository.GetAll());
        }

        // GET: CategoriaCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaCurso = await _categoriaCursoRepository.GetById(id.Value);
            if (categoriaCurso == null)
            {
                return NotFound();
            }

            return View(categoriaCurso);
        }

        // GET: CategoriaCursos/Create
        public IActionResult Create()
        {
            // Similar lógica para SelectList
            return View();
        }

        // POST: CategoriaCursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,CategoriaId,Nombre")] CategoriaCurso categoriaCurso)
        {
            if (ModelState.IsValid)
            {
                await _categoriaCursoRepository.Create(categoriaCurso);
                return RedirectToAction(nameof(Index));
            }
            // Similar lógica para SelectList en caso de error
            return View(categoriaCurso);
        }

        // GET: CategoriaCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaCurso = await _categoriaCursoRepository.GetById(id.Value);
            if (categoriaCurso == null)
            {
                return NotFound();
            }

            // Similar lógica para SelectList
            return View(categoriaCurso);
        }

        // POST: CategoriaCursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,CategoriaId,Nombre")] CategoriaCurso categoriaCurso)
        {
            if (id != categoriaCurso.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaCursoRepository.Update(categoriaCurso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _categoriaCursoRepository.Exists(categoriaCurso.CursoId))
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
            // Similar lógica para SelectList en caso de error
            return View(categoriaCurso);
        }

        // GET: CategoriaCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaCurso = await _categoriaCursoRepository.GetById(id.Value);
            if (categoriaCurso == null)
            {
                return NotFound();
            }

            return View(categoriaCurso);
        }

        // POST: CategoriaCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaCursoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
