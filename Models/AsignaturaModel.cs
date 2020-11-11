using System;
using System.Collections.Generic;

namespace WebCore.Models
{
    public class AsignaturaModel : ParentEntityModel
    {
        public string CursoModelUniqueId { get; set; }
        public CursoModel Curso { get; set; }

        public List<EvaluacionModel> Evaluaciones { get; set; }

        public AsignaturaModel() => UniqueId = Guid.NewGuid().ToString();
    }
}
