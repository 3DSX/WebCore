using System;

namespace WebCore.Models
{
    public class AsignaturaModel : ParentEntityModel
    {
        public AsignaturaModel() => UniqueId = Guid.NewGuid().ToString();
    }
}
