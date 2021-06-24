using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Controllers
{
    public class CandidateController : Controller
    {
        private readonly DataContext _context;

        public List<Candidate> Candidate { get; set; }

        public CandidateController(DataContext context) {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var Test = _context.candidate.Include(e=> e.Evaluations);
            return View(await Test.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Candidate newCandidate) {
            if (ModelState.IsValid)
            {
                _context.Add(newCandidate);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else {
                return View(newCandidate);
            }
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var candidate = await _context.candidate.FindAsync(id);
            if (candidate == null) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException) {
                    return NotFound();
                }
                
            }
            return View(candidate);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include:"CandidateID,Name,LastName,Area,Identification,PhoneNumber,dateCandidate")] Candidate candidate1) {

            if (ModelState.IsValid)
            {
                _context.Entry(candidate1).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate1);
            
        } 


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.candidate.Include(e => e.Evaluations)
                .FirstOrDefaultAsync(m => m.CandidateID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.candidate
                .FirstOrDefaultAsync(c => c.CandidateID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate= await _context.candidate.FindAsync(id);
            _context.candidate.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
