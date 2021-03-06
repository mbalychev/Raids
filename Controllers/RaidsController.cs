﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raids.Data;
using Raids.Models;
using Raids.Models.Adds;

namespace Raids.Controllers
{
    public class RaidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Raids
        public async Task<IActionResult> Index(string search, string sortNumber, string sortDate, int filterTerr, DateTime start, DateTime stop, string filter)
        {
            FilterParams filterParams = new FilterParams(search, sortNumber, sortDate, filterTerr, start, stop, filter);

            List<Raid> raids = await Models.Adds.FilterParams.GetRaidsAsync(_context, filterParams);

            ViewData["FilterTerr"] = filterTerr;
            ViewData["Start"] = filterParams.Start;
            ViewData["Stop"] = filterParams.Stop;
            ViewData["Terr"] = await _context.Terrs.AsNoTracking().ToListAsync();
            ViewData["Search"] = search;
            ViewData["SortNumber"] = sortNumber == "asc" ? "desc" : "asc";
            if (string.IsNullOrEmpty(sortNumber)) sortNumber = "asc";

            ViewData["SortDate"] = sortDate == "asc" ? "desc" : "asc";
            if (string.IsNullOrEmpty(sortDate)) sortDate = "asc";

            return View(raids);
        }


        // GET: Raids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raid = await _context.Raids
                .Include(t => t.Terr)
                .Include(t => t.Rpokazatel).ThenInclude(r => r.Pokazatel)
                .Include(r => r.Risp).ThenInclude(i => i.Isp)
                .Include(r => r.Rfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raid == null)
            {
                return NotFound();
            }

            return View(raid);
        }

        // GET: Raids/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Terr"] = await _context.Terrs.AsNoTracking().ToListAsync();
            return View();
        }

        // POST: Raids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nomer,Prikaz,Start,Stop,TerrId,Close")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Raids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raid = await _context.Raids.FindAsync(id);
            if (raid == null)
            {
                return NotFound();
            }
            ViewData["Terr"] = await _context.Terrs.AsNoTracking().ToListAsync();
            return View(raid);
        }

        // POST: Raids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nomer,Prikaz,Start,Stop,TerrId,Close")] Raid raid)
        {
            if (id != raid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (raid.Start > raid.Stop)
                {
                    ModelState.AddModelError("", "Дата завершения не может быть меньше даты начала");
                    ViewData["Terr"] = await _context.Terrs.AsNoTracking().ToListAsync();
                    return View(raid);
                }
                try
                {
                    _context.Update(raid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaidExists(raid.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return View(raid);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Raids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raid = await _context.Raids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raid == null)
            {
                return NotFound();
            }

            return View(raid);
        }

        // POST: Raids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raid = await _context.Raids.FindAsync(id);
            _context.Raids.Remove(raid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaidExists(int id)
        {
            return _context.Raids.Any(e => e.Id == id);
        }

    }
}
