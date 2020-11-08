using System;
using System.Collections.Generic;

namespace WebCore.Models
{
    public class CursoModel : ParentEntityModel
    {
        public TiposJornadaModel Jornada { get; set; }

        public List<AsignaturaModel> Asignaturas { get; set; }

        public List<AlumnoModel> Alumno { get; set; }

        public string EscuelaModelUniqueId { get; set; }
        public EscuelaModel Escuela { get; set; }

        public CursoModel() => UniqueId = Guid.NewGuid().ToString();
    }
}
