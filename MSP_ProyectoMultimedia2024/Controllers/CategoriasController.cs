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
    public class CategoriasController : Controller
    {
        private readonly ICategorias _categoriasRepository;

        public CategoriasController(ICategorias categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _categoriasRepository.GetAllAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var categorias = await _categoriasRepository.GetDetailsAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                await _categoriasRepository.AddAsync(categorias);
                return RedirectToAction(nameof(Index));
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var categorias = await _categoriasRepository.GetEditAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Categorias categorias)
        {
            if (id != categorias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriasRepository.UpdateAsync(categorias);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoriasRepository.CategoriasExists(categorias.Id))
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
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var categorias = await _categoriasRepository.GetDeleteAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriasRepository.DeleteConfirmedAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id)
        {
            return _categoriasRepository.CategoriasExists(id);
        }
    }


}
