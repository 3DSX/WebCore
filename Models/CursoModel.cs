using System.Collections.Generic;

namespace WebCore.Models
{
    public class CursoModel : ParentEntityModel
    {
        public TiposJornadaModel Jornada { get; set; }

        public List<AsignaturaModel> Asignaturas { get; set; }
        public List<AlumnoModel> Alumno { get; set; }
    }
}
