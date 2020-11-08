using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebCore.Models
{
    // [DebuggerDisplay("")]
    public class EvaluacionModel : ParentEntityModel
    {
        public string AsignaturaUniqueId { get; set; }
        public AsignaturaModel Asignatura { get; set; }

        public string AlumnoUniqueId { get; set; }
        public AlumnoModel Alumno { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota},{Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}
