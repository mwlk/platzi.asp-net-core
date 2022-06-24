using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Platzi.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Escuela> Escuelas { get; set; }

        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var escuela =
                new Escuela {
                    Id = Guid.NewGuid().ToString(),
                    Fundacion = 1994,
                    Nombre = "IDES",
                    Direccion = "laprida 53",
                    Pais = "Arg",
                    Ciudad = "Cordoba",
                    TipoEscuela = TiposEscuela.Secundaria
                };

            // var alumnos = GenerarAlumnosAlAzar(15);
            var cursos = GenerarCursos(escuela);
            List<Alumno> listadoAlumnos = new List<Alumno>();
            foreach (var curso in cursos)
            {
                var alumnos = GenerarAlumnosAlAzar(curso, 20);

                listadoAlumnos.AddRange (alumnos);
            }

            var asignaturas = CargarAsignaturas(cursos);

            builder.Entity<Escuela>().HasData(escuela);
            builder.Entity<Curso>().HasData(cursos.ToArray());
            builder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            builder.Entity<Alumno>().HasData(listadoAlumnos.ToArray());
        }

        protected private List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List<Asignatura> asignaturasAsignadas = new List<Asignatura>();

            //! asignaturas asignadas
            foreach (var curso in cursos)
            {
                var asignaturas = GenerarAsignaturas(curso.Id);
                // curso.Asignaturas = asignaturas;
                asignaturasAsignadas.AddRange (asignaturas);
            }

            return asignaturasAsignadas;
        }

        protected private List<Curso> GenerarCursos(Escuela escuela)
        {
            string[] nombreCursos =
            { "primero", "segundo", "tercero", "cuarto", "quinto", "sexto" };
            string[] salaCursos = { "A", "B" };

            var listadoCursos =
                from nc in nombreCursos
                from sc in salaCursos
                select
                new Curso {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = $"{nc}{'-'}{sc}",
                    EscuelaId = escuela.Id,
                    Jornada = TiposJornada.Mañana
                };

            return listadoCursos.OrderBy(c => c.Id).ToList();
        }

        protected private List<Asignatura> GenerarAsignaturas(string id)
        {
            var listaAsignaturas =
                new List<Asignatura>()
                {
                    new Asignatura {
                        Nombre = "Matemáticas",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = id
                    },
                    new Asignatura {
                        Nombre = "Educación Física",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = id
                    },
                    new Asignatura {
                        Nombre = "Castellano",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = id
                    },
                    new Asignatura {
                        Nombre = "Ciencias Naturales",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = id
                    },
                    new Asignatura {
                        Nombre = "Programacion",
                        Id = Guid.NewGuid().ToString(),
                        CursoId = id
                    }
                };

            return listaAsignaturas;
        }

        protected private List<Alumno>
        GenerarAlumnosAlAzar(Curso curso, int cantSillas)
        {
            string[] nombre1 =
            {
                "Alba",
                "Felipa",
                "Eusebio",
                "Farid",
                "Donald",
                "Alvaro",
                "Nicolás"
            };
            string[] apellido1 =
            {
                "Ruiz",
                "Sarmiento",
                "Uribe",
                "Maduro",
                "Trump",
                "Toledo",
                "Herrera"
            };
            string[] nombre2 =
            {
                "Freddy",
                "Anabel",
                "Rick",
                "Murty",
                "Silvana",
                "Diomedes",
                "Nicomedes",
                "Teodoro"
            };

            var listaAlumnos =
                from n1 in nombre1
                from n2 in nombre2
                from a1 in apellido1
                select
                new Alumno {
                    Nombre = $"{n1} {n2} {a1}",
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id
                };

            return listaAlumnos
                .OrderBy((al) => al.Id)
                .Take(cantSillas)
                .ToList();
        }
    }
}
