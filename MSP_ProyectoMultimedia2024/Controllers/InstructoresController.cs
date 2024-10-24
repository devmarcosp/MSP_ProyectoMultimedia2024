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
    public class InstructoresController : Controller
    {
        private readonly IInstructores _instructoresRepository;

        public InstructoresController(IInstructores instructoresRepository)
        {
            _instructoresRepository = instructoresRepository;
        }

        // GET: Instructores
        public async Task<IActionResult> Index()
        {
            
            return View(await _instructoresRepository.GetAllAsync());
        }

        public async Task<IActionResult> ListaInstructores()
        {

            return PartialView(await _instructoresRepository.GetAllAsync());
        }


        // GET: Instructores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructores = await _instructoresRepository.GetByIdAsync(id);
            if (instructores == null)
            {
                return NotFound();
            }

            return View(instructores);
        }

        // GET: Instructores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstructor,NombreInstructor,Especialidad,Email")] Instructores instructores)
        {
            if (ModelState.IsValid)
            {
                await _instructoresRepository.AddAsync(instructores);
                return RedirectToAction(nameof(Index));
            }
            return View(instructores);
        }

        // GET: Instructores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructores = await _instructoresRepository.GetByIdAsync(id);
            if (instructores == null)
            {
                return NotFound();
            }
            return View(instructores);
        }

        // POST: Instructores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstructor,NombreInstructor,Especialidad,Email")] Instructores instructores)
        {
            if (id != instructores.IdInstructor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _instructoresRepository.UpdateAsync(instructores);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_instructoresRepository.InstructorExists(instructores.IdInstructor))
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
            return View(instructores);
        }

        // GET: Instructores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructores = await _instructoresRepository.GetByIdAsync(id);
            if (instructores == null)
            {
                return NotFound();
            }

            return View(instructores);
        }

        // POST: Instructores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _instructoresRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


}
