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
    }
}
