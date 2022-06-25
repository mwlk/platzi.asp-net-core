using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Platzi.Models;

namespace Platzi.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ILogger<AlumnoController> _logger;

        private readonly EscuelaContext _context;

        public AlumnoController(
            ILogger<AlumnoController> logger,
            EscuelaContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        [Route("alumno")]
        [Route("alumno/{alumnoId}")]
        public IActionResult Index(string alumnoId)
        {
            if (!string.IsNullOrEmpty(alumnoId))
            {
                var alumno =
                    from al in _context.Alumnos
                    where al.Id == alumnoId select al;

                return View(alumno.SingleOrDefault());
            }
            return View("MultiAlumno", _context.Alumnos.ToList());
        }

        public IActionResult MultiAlumno()
        {
            var listado = _context.Alumnos.ToList();

            return View(listado);
        }

        [
            ResponseCache(
                Duration = 0,
                Location = ResponseCacheLocation.None,
                NoStore = true)
        ]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
