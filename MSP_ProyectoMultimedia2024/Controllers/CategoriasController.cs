using MSP_ProyectoMultimedia2024.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var categorias = await _categoriasRepository.GetAllAsync();
            return View(categorias);  // Asegúrate de tener una vista llamada Index.cshtml
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] CategoriasDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoriasRepository.AddAsync(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var categoriaDTO = await _categoriasRepository.GetEditAsync(id);
            if (categoriaDTO == null)
            {
                return NotFound();
            }
            return View(categoriaDTO);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CategoriasDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriasRepository.UpdateAsync(categoriaDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoriasRepository.CategoriasExists(categoriaDTO.Id))
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
            return View(categoriaDTO);
        }
    }
}
