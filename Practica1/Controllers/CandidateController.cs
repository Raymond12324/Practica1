﻿using Microsoft.AspNetCore.Mvc;
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
            var Test = _context.candidate.Include(c => c.Evaluations);
            return View(await Test.ToListAsync());
        }

   
    }
}
