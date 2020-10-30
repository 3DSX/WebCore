using System;

namespace WebCore.Models
{
    public abstract class ParentEntityModel
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }

        public ParentEntityModel()
        {

        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}
