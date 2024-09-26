﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSP_ProyectoMultimedia2024.Models.Contexts;
using MSP_ProyectoMultimedia2024.Models.Tables;
using MSP_ProyectoMultimedia2024.Services.Interfaces;
using NuGet.ProjectModel;

namespace MSP_ProyectoMultimedia2024.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarios _usuariosService;

        public UsuariosController(IUsuarios usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuariosService.GetUsuariosAsync();
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _usuariosService.GetUsuarioByIdAsync(id.Value);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Password,TipoUsuario,FechaRegistro")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuariosService.AddUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _usuariosService.GetUsuarioByIdAsync(id.Value);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Password,TipoUsuario,FechaRegistro")] Usuarios usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _usuariosService.UpdateUsuarioAsync(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UsuarioExists(usuario.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _usuariosService.GetUsuarioByIdAsync(id.Value);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuariosService.DeleteUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UsuarioExists(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            return usuario != null;
        }
    }
}

