using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Platzi.Models;

namespace Platzi.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly EscuelaContext _context;

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);
        }
    }
}
