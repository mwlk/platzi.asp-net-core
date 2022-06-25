using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Platzi.Models;

namespace Platzi.Controllers
{
    public class CursoController : Controller
    {
        private readonly EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

        [Route("curso")]
        [Route("curso/{cursoId}")]
        public IActionResult Index(string cursoId)
        {
            if (!string.IsNullOrEmpty(cursoId))
            {
                var curso =
                    from c in _context.Cursos where c.Id == cursoId select c;

                return View(curso.SingleOrDefault());
            }
            return View("MultiCurso", _context.Cursos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;

                _context.Cursos.Add (curso);
                _context.SaveChanges();

                ViewBag.Response = "Curso Creado con exito";

                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
    }
}
