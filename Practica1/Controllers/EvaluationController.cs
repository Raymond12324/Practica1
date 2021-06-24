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

    public class EvaluationController : Controller
    {
        private readonly DataContext _context;

        public List<Evaluation> Candidate { get; set; }

        public EvaluationController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Test = _context.evaluation.Include(c => c.Candidate);
            return View(await Test.ToListAsync());
        }

        public ActionResult Create(int id)
        {

            ViewBag.item = id;
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Evaluation newEvaluation)
        {
            newEvaluation.DateEvaluation = DateTime.Now;
            if (ModelState.IsValid)
            {                    
                _context.Add(newEvaluation);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newEvaluation);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

            }
            return View(evaluation);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "EvaluationID,RRHH_evaluator,evaluation,Commentary,CandidateID,dateEvaluation")] Evaluation Myevaluation)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(Myevaluation).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Myevaluation);

        }

    

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluation.Include(c => c.Candidate)
                .FirstOrDefaultAsync(m => m.EvaluationID == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }


        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.evaluation
                .FirstOrDefaultAsync(c => c.EvaluationID == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.evaluation.FindAsync(id);
            _context.evaluation.Remove(evaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
