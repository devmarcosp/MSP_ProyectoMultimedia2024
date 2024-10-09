using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services;
using MSP_ProyectoMultimedia2024.Services.Repository;
using System.Threading.Tasks;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursos _cursosService;

        public CursosController(ICursos cursosService)
        {
            _cursosService = cursosService;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var cursos = await _cursosService.GetCursosAsync();
            return View(cursos);
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
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDTO = await _cursosService.GetEditAsync(id);
            if (cursoDTO == null)
            {
                return NotFound();
            }
            return View(cursoDTO);
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
                catch
                {
                    if (!await _cursosService.CursosExistsAsync(curso.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
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
