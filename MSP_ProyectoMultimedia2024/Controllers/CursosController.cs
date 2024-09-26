using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;
using System.Threading.Tasks;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursos _cursosService;
        private readonly CleverlandContext _context;

        public CursosController(ICursos cursosService, CleverlandContext context)
        {
            _cursosService = cursosService;
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var obtenerIndex = await _cursosService.GetCursosAsync();
            return View(obtenerIndex);
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursosService.GetDetailsAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(_context.Usuarios, "Id", "Id");//editar aca join
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,InstructorId,FechaCreacion")] Cursos curso)
        {
            if (ModelState.IsValid)
            {
                await _cursosService.AddCursoAsync(curso);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Usuarios, "Id", "Id", curso.InstructorId);//editar
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursosService.GetDetailsAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Usuarios, "Id", "Id", curso.InstructorId);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,InstructorId,FechaCreacion")] Cursos curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cursosService.UpdateCursoAsync(curso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _cursosService.CursosExistsAsync(curso.Id))
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
            ViewData["InstructorId"] = new SelectList(_context.Usuarios, "Id", "Id", curso.InstructorId);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursosService.GetDetailsAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cursosService.DeleteCursoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
