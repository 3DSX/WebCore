
using System.Collections.Generic;

namespace WebCore.Models
{
    public class AlumnoModel : ParentEntityModel
    {
        public List<EvaluacionModel> Evaluaciones { get; set; }

    }
}
