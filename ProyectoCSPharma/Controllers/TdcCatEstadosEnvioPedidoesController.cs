﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoCSPharma.Controllers
{
    [Authorize(Roles = "Administradores, Usuarios")]
    public class TdcCatEstadosEnvioPedidoesController : Controller
    {
        private readonly CspharmaInformacionalContext _context;

        public TdcCatEstadosEnvioPedidoesController(CspharmaInformacionalContext context)
        {
            _context = context;
        }

        // GET: TdcCatEstadosEnvioPedidoes
        public async Task<IActionResult> Index(string buscar)
        {
            //Query para el filtro de búsqueda

            var envioPed = from pedido in _context.TdcCatEstadosEnvioPedidos select pedido;

            if (!string.IsNullOrEmpty(buscar))
            {
                envioPed = envioPed.Where(p => p.DesEstadoEnvio!.Contains(buscar));
            }

            return View(await envioPed.ToListAsync());
        }


        // GET: TdcCatEstadosEnvioPedidoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos
                .FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TdcCatEstadosEnvioPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDate,Id,CodEstadoEnvio,DesEstadoEnvio")] TdcCatEstadosEnvioPedido tdcCatEstadosEnvioPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdcCatEstadosEnvioPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }
            return View(tdcCatEstadosEnvioPedido);
        }

        // POST: TdcCatEstadosEnvioPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MdUuid,MdDate,Id,CodEstadoEnvio,DesEstadoEnvio")] TdcCatEstadosEnvioPedido tdcCatEstadosEnvioPedido)
        {
            if (id != tdcCatEstadosEnvioPedido.CodEstadoEnvio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdcCatEstadosEnvioPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcCatEstadosEnvioPedidoExists(tdcCatEstadosEnvioPedido.CodEstadoEnvio))
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
            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos
                .FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosEnvioPedido);
        }

        // POST: TdcCatEstadosEnvioPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TdcCatEstadosEnvioPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcCatEstadosEnvioPedidos'  is null.");
            }
            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);
            if (tdcCatEstadosEnvioPedido != null)
            {
                _context.TdcCatEstadosEnvioPedidos.Remove(tdcCatEstadosEnvioPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdcCatEstadosEnvioPedidoExists(string id)
        {
          return _context.TdcCatEstadosEnvioPedidos.Any(e => e.CodEstadoEnvio == id);
        }
    }
}
