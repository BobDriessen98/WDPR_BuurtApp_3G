using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDPR_BuurtApp_3G.Data;
using WDPR_BuurtApp_3G.Models;

namespace WDPR_BuurtApp_3G.Controllers
{
    public class ReactiesController : Controller
    {
        private readonly WDPR_BuurtApp_3GContext _context;

        public ReactiesController(WDPR_BuurtApp_3GContext context)
        {
            _context = context;
        }

        // GET: Reacties
        public async Task<IActionResult> Index()
        {
            var wDPR_BuurtApp_3GContext = _context.Reactie.Include(r => r.User).Include(r => r.melding);
            return View(await wDPR_BuurtApp_3GContext.ToListAsync());
        }

        // GET: Reacties/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactie = await _context.Reactie
                .Include(r => r.User)
                .Include(r => r.melding)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (reactie == null)
            {
                return NotFound();
            }

            return View(reactie);
        }

        // GET: Reacties/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MeldingID"] = new SelectList(_context.Melding, "MeldingID", "MeldingID");
            return View();
        }

        // POST: Reacties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,MeldingID,Datum,Reactietekst")] Reactie reactie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reactie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", reactie.UserID);
            ViewData["MeldingID"] = new SelectList(_context.Melding, "MeldingID", "MeldingID", reactie.MeldingID);
            return View(reactie);
        }

        // GET: Reacties/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactie = await _context.Reactie.FindAsync(id);
            if (reactie == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", reactie.UserID);
            ViewData["MeldingID"] = new SelectList(_context.Melding, "MeldingID", "MeldingID", reactie.MeldingID);
            return View(reactie);
        }

        // POST: Reacties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,MeldingID,Datum,Reactietekst")] Reactie reactie)
        {
            if (id != reactie.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reactie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReactieExists(reactie.UserID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", reactie.UserID);
            ViewData["MeldingID"] = new SelectList(_context.Melding, "MeldingID", "MeldingID", reactie.MeldingID);
            return View(reactie);
        }

        // GET: Reacties/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactie = await _context.Reactie
                .Include(r => r.User)
                .Include(r => r.melding)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (reactie == null)
            {
                return NotFound();
            }

            return View(reactie);
        }

        // POST: Reacties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reactie = await _context.Reactie.FindAsync(id);
            _context.Reactie.Remove(reactie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReactieExists(string id)
        {
            return _context.Reactie.Any(e => e.UserID == id);
        }
    }
}
