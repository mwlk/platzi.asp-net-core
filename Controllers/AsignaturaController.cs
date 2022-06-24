using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Platzi.Models;

namespace Platzi.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        // public IActionResult Index()
        // {
        //     var asignatura = _context.Asignaturas.FirstOrDefault();
        //     return View(asignatura);
        // }
        [Route("asignatura")]
        [Route("asignatura/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrEmpty(asignaturaId))
            {
                var asignatura =
                    from asig in _context.Asignaturas
                    where asig.Id == asignaturaId select asig;

                return View(asignatura.SingleOrDefault());
            }
            return View("MultiAsignatura", _context.Asignaturas.ToList());
        }

        public IActionResult MultiAsignatura()
        {
            var listado = _context.Asignaturas.ToList();

            return View(listado);
        }
    }
}
