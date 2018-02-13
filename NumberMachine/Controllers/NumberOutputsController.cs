using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NumberMachine.Models;

namespace NumberMachine.Controllers
{
    public class NumberOutputsController : Controller
    {
        private readonly NumberMachineContext _context;

        public NumberOutputsController(NumberMachineContext context)
        {
            _context = context;
        }

        // GET: NumberOutputs
        public async Task<IActionResult> Index()
        {
            var numberMachineContext = _context.NumberOutput.Include(n => n.Input);
            return View(await numberMachineContext.ToListAsync());
        }

        // GET: NumberOutputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberOutput = await _context.NumberOutput
                .Include(n => n.Input)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberOutput == null)
            {
                return NotFound();
            }

            return View(numberOutput);
        }

        // GET: NumberOutputs/Create
        public IActionResult Create()
        {
            ViewData["InputID"] = new SelectList(_context.NumberInput, "ID", "ID");
            return View();
        }

        // POST: NumberOutputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,InputID,Operation,Output")] NumberOutput numberOutput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberOutput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InputID"] = new SelectList(_context.NumberInput, "ID", "ID", numberOutput.InputID);
            return View(numberOutput);
        }

        // GET: NumberOutputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberOutput = await _context.NumberOutput.SingleOrDefaultAsync(m => m.ID == id);
            if (numberOutput == null)
            {
                return NotFound();
            }
            ViewData["InputID"] = new SelectList(_context.NumberInput, "ID", "ID", numberOutput.InputID);
            return View(numberOutput);
        }

        // POST: NumberOutputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,InputID,Operation,Output")] NumberOutput numberOutput)
        {
            if (id != numberOutput.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberOutput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberOutputExists(numberOutput.ID))
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
            ViewData["InputID"] = new SelectList(_context.NumberInput, "ID", "ID", numberOutput.InputID);
            return View(numberOutput);
        }

        // GET: NumberOutputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberOutput = await _context.NumberOutput
                .Include(n => n.Input)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberOutput == null)
            {
                return NotFound();
            }

            return View(numberOutput);
        }

        // POST: NumberOutputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberOutput = await _context.NumberOutput.SingleOrDefaultAsync(m => m.ID == id);
            _context.NumberOutput.Remove(numberOutput);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberOutputExists(int id)
        {
            return _context.NumberOutput.Any(e => e.ID == id);
        }
    }
}
