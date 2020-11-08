using System;
using System.ComponentModel.DataAnnotations;

namespace WebCore.Models
{
    public abstract class ParentEntityModel
    {
        [Key]
        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}
