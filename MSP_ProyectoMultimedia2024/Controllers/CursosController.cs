using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSP_ProyectoMultimedia2024.Models.Dto;
using MSP_ProyectoMultimedia2024.Services;
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
            return View(await _cursosService.GetCursosAsync());
        }

        public async Task<IActionResult> ListaCursos()
        {
            return PartialView(await _cursosService.GetCursosAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,InstructorId,FechaCreacion")] CursosDTO cursoDto)
        {
            if (ModelState.IsValid)
            {
                await _cursosService.AddCursoAsync(cursoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(cursoDto);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDTO = await _cursosService.GetEditAsync(id.Value);
            if (cursoDTO == null)
            {
                return NotFound();
            }
            return View(cursoDTO);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,InstructorId,FechaCreacion")] CursosDTO cursoDto)
        {
            if (id != cursoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cursosService.UpdateCursoAsync(cursoDto);
                }
                catch
                {
                    if (!await _cursosService.CursosExistsAsync(cursoDto.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cursoDto);
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
