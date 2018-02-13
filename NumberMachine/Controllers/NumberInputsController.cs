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
    public class NumberInputsController : Controller
    {
        private readonly NumberMachineContext _context;

        public NumberInputsController(NumberMachineContext context)
        {
            _context = context;
        }

        // GET: NumberInputs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumberInput.ToListAsync());
        }

        // GET: NumberInputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberInput = await _context.NumberInput
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberInput == null)
            {
                return NotFound();
            }

            return View(numberInput);
        }

        // GET: NumberInputs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumberInputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,n,m")] NumberInput numberInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numberInput);
        }

        // GET: NumberInputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberInput = await _context.NumberInput.SingleOrDefaultAsync(m => m.ID == id);
            if (numberInput == null)
            {
                return NotFound();
            }
            return View(numberInput);
        }

        // POST: NumberInputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,n,m")] NumberInput numberInput)
        {
            if (id != numberInput.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberInputExists(numberInput.ID))
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
            return View(numberInput);
        }

        // GET: NumberInputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberInput = await _context.NumberInput
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberInput == null)
            {
                return NotFound();
            }

            return View(numberInput);
        }

        // POST: NumberInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberInput = await _context.NumberInput.SingleOrDefaultAsync(m => m.ID == id);
            _context.NumberInput.Remove(numberInput);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberInputExists(int id)
        {
            return _context.NumberInput.Any(e => e.ID == id);
        }
    }
}
