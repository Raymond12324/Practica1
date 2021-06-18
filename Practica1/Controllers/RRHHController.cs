using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Controllers
{
    public class RRHHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
