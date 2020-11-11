using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebCore.Models
{
    // [DebuggerDisplay("")]
    public class EvaluacionModel : ParentEntityModel
    {

        public AsignaturaModel Asignatura { get; set; }

        public AlumnoModel evOwner { get; set; }
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota},{evOwner.Nombre}, {Asignatura.Nombre}";
        }
    }
}
