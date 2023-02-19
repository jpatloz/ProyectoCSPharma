using System;
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
    public class TdcCatEstadosDevolucionPedidoesController : Controller
    {
        private readonly CspharmaInformacionalContext _context;

        public TdcCatEstadosDevolucionPedidoesController(CspharmaInformacionalContext context)
        {
            _context = context;
        }

        // GET: TdcCatEstadosDevolucionPedidoes
        public async Task<IActionResult> Index(string buscar)
        {
            //Query para el filtro de búsqueda

            var estadoPed = from pedido in _context.TdcCatEstadosDevolucionPedidos select pedido;

            if (!string.IsNullOrEmpty(buscar))
            {
                estadoPed = estadoPed.Where(p => p.DesEstadoDevolucion!.Contains(buscar));
            }

              return View(await estadoPed.ToListAsync());
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos
                .FirstOrDefaultAsync(m => m.CodEstadoDevolucion == id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDate,Id,CodEstadoDevolucion,DesEstadoDevolucion")] TdcCatEstadosDevolucionPedido tdcCatEstadosDevolucionPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdcCatEstadosDevolucionPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }
            return View(tdcCatEstadosDevolucionPedido);
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MdUuid,MdDate,Id,CodEstadoDevolucion,DesEstadoDevolucion")] TdcCatEstadosDevolucionPedido tdcCatEstadosDevolucionPedido)
        {
            if (id != tdcCatEstadosDevolucionPedido.CodEstadoDevolucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdcCatEstadosDevolucionPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcCatEstadosDevolucionPedidoExists(tdcCatEstadosDevolucionPedido.CodEstadoDevolucion))
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
            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos
                .FirstOrDefaultAsync(m => m.CodEstadoDevolucion == id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosDevolucionPedido);
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TdcCatEstadosDevolucionPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcCatEstadosDevolucionPedidos'  is null.");
            }
            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);
            if (tdcCatEstadosDevolucionPedido != null)
            {
                _context.TdcCatEstadosDevolucionPedidos.Remove(tdcCatEstadosDevolucionPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdcCatEstadosDevolucionPedidoExists(string id)
        {
          return _context.TdcCatEstadosDevolucionPedidos.Any(e => e.CodEstadoDevolucion == id);
        }
    }
}
