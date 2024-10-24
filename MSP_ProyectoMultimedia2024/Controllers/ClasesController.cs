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
    public class ClasesController : Controller
    {
        private readonly IClases _clasesRepository;

        public ClasesController(IClases clasesRepository)
        {
            _clasesRepository = clasesRepository;
        }

        // GET: Clases
        public async Task<IActionResult> Index()
        {
            var clases = await _clasesRepository.GetAll();  
            return View(clases); 
        }

        public async Task<IActionResult> ListaClases()
        {
            var clases = await _clasesRepository.GetAll();
            return PartialView(clases);
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _clasesRepository.GetById(id.Value);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clases/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CursoId"] = new SelectList(await _clasesRepository.GetAll(), "Id", "Descripcion");
            return View();
        }


        // POST: Clases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Contenido,UrlVideo,CursoId,Orden")] Clases clase)
        {
            if (ModelState.IsValid)
            {
                await _clasesRepository.Create(clase);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(await _clasesRepository.GetAll(), "Id", "Descripcion", clase.CursoId);
            return View(clase);
        }

        // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _clasesRepository.GetById(id.Value);
            if (clase == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(await _clasesRepository.GetAll(), "Id", "Descripcion", clase.CursoId);
            return View(clase);
        }

        // POST: Clases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Contenido,UrlVideo,CursoId,Orden")] Clases clase)
        {
            if (id != clase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clasesRepository.Update(clase);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(await _clasesRepository.GetAll(), "Id", "Descripcion", clase.CursoId);
            return View(clase);
        }

        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _clasesRepository.GetById(id.Value);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clasesRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClasesExists(int id)
        {
            return await _clasesRepository.Exists(id);
        }
    }
}

