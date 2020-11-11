using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebCore.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<EscuelaModel> Escuelas { get; set; }

        public DbSet<CursoModel> Cursos { get; set; }

        public DbSet<AsignaturaModel> Asignaturas { get; set; }

        public DbSet<AlumnoModel> Alumnos { get; set; }

        public DbSet<EvaluacionModel> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> opciones) : base(opciones)
        {

        }

        #region Siembra de Datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new EscuelaModel
            {
                YearOfCreation = 1998,
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Academia Kadic",
                Ciudad = "París",
                TipoEscuela = TiposEscuelaModel.Bachillerato,
                Direccion = "La Mezquita",
                Pais = "Francia"
            };

            var cursos = CargarCursos(escuela, out List<AlumnoModel> alumnos);

            var asignaturas = CargarAsignaturas(cursos);


            modelBuilder.Entity<EscuelaModel>().HasData(escuela);

            modelBuilder.Entity<CursoModel>().HasData(cursos);

            modelBuilder.Entity<AsignaturaModel>().HasData(asignaturas);

            modelBuilder.Entity<AlumnoModel>().HasData(alumnos);

        }
        #endregion

        private List<AlumnoModel> InicializarAlumnos(CursoModel curso, int maxAlums = 30)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               orderby n1, n2, a1 ascending
                               select new AlumnoModel()
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   CursoModelUniqueId = curso.UniqueId
                               };



            return listaAlumnos.Take(maxAlums).ToList();


        }

        private List<CursoModel> CargarCursos(EscuelaModel escuela, out List<AlumnoModel> alumnosTotales)
        {
            alumnosTotales = new List<AlumnoModel>();

            List<CursoModel> cursos = new List<CursoModel>
            {
                new CursoModel()
                {
                Nombre = "Curso 101",
                EscuelaModelUniqueId = escuela.UniqueId,
                Jornada = TiposJornadaModel.Mañana
                },
                new CursoModel()
                {
                    Nombre = "Curso 201",
                    EscuelaModelUniqueId = escuela.UniqueId,
                    Jornada = TiposJornadaModel.Mañana
                },
                new CursoModel()
                {
                    Nombre = "Curso 301",
                    EscuelaModelUniqueId = escuela.UniqueId,
                    Jornada = TiposJornadaModel.Tarde
                },
                new CursoModel()
                {
                    Nombre = "Curso 404",
                    EscuelaModelUniqueId = escuela.UniqueId,
                    Jornada = TiposJornadaModel.Tarde
                },
                new CursoModel()
                {
                    Nombre = "Curso 504",
                    EscuelaModelUniqueId = escuela.UniqueId,
                    Jornada = TiposJornadaModel.Noche
                }
            };

            Random rnd = new Random();
            foreach (CursoModel curso in cursos)
            {
                int numeroAleatorio = rnd.Next(10, 20);
                var alumnosCurso = InicializarAlumnos(curso, numeroAleatorio);
                //Ya añadido por convención: curso.Alumno = alumnosCurso;
                alumnosTotales.AddRange(alumnosCurso);
            }

            return cursos;
        }

        private List<AsignaturaModel> CargarAsignaturas(List<CursoModel> Cursos)
        {
            List<AsignaturaModel> asignaturasTotales = new List<AsignaturaModel>();

            foreach (CursoModel curso in Cursos)
            {
                List<AsignaturaModel> asignaturasTmp = new List<AsignaturaModel> {
                    new AsignaturaModel() { Nombre = "Francés", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "Español", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "Inglés", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "Química", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "Matemáticas", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "E.F", CursoModelUniqueId = curso.UniqueId },
                    new AsignaturaModel() { Nombre = "Programación", CursoModelUniqueId = curso.UniqueId }};

                //Ya añadido por convención: curso.Asignaturas = asignaturasTmp;
                asignaturasTotales.AddRange(asignaturasTmp);
            };

            return asignaturasTotales;
        }

    }
}
