using System;
using System.Collections.Generic;


namespace Platzi.Models
{
    public class Escuela : ObjetoEscuelaBase
    {
        public int Fundacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año) => (Nombre, Fundacion) = (nombre, año);

        public Escuela(string nombre, int año,
                       TiposEscuela tipo,
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, Fundacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public Escuela()
        {

        }
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}
