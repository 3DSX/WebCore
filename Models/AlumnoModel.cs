
using System.Collections.Generic;
using System;

namespace WebCore.Models
{
    public class AlumnoModel : ParentEntityModel
    {
        public List<EvaluacionModel> Evaluaciones { get; set; }

        public AlumnoModel() => UniqueId = Guid.NewGuid().ToString();

    }
}
