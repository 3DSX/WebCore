using System.Collections.Generic;

namespace WebCore.Models
{
    public class EscuelaModel : ParentEntityModel
    {
        /*
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }
        */

        public int YearOfCreation { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuelaModel TipoEscuela { get; set; }

        public List<CursoModel> Cursos { get; set; }

        public EscuelaModel()
        {

        }

        public EscuelaModel(string nombre, int year) => (Nombre, YearOfCreation) = (nombre, year);

        public EscuelaModel(string nombre, int year, TiposEscuelaModel tipo, string pais = "", string ciudad = "")
        {
            (Nombre, YearOfCreation) = (nombre, year);
            Pais = pais;
            Ciudad = ciudad;
            TipoEscuela = tipo;
        }

        public override string ToString()
        {
            string newLine = System.Environment.NewLine;
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {newLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}