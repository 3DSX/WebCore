using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCore.Models
{
    public class CursoModel : ParentEntityModel
    {
        public TiposJornadaModel Jornada { get; set; }

        [Required(ErrorMessage = "No has elegido un nombre!")]
        [StringLength(20, ErrorMessage = "El nombre no puede ser superior a 20 carácteres")]
        [MinLength(5, ErrorMessage = "El nombre no puede ser menor a 5 carácteres")]
        [Display(Prompt = "Nombre del Curso", Name = "Nombre")]

        public override string Nombre { get; set; }

        public List<AsignaturaModel> Asignaturas { get; set; }

        public List<AlumnoModel> Alumno { get; set; }

        public string EscuelaModelUniqueId { get; set; }
        public EscuelaModel Escuela { get; set; }

        public CursoModel() => UniqueId = Guid.NewGuid().ToString();
    }
}
