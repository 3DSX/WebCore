using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            var alumno = new AlumnoModel
            {
                Nombre = "Jorge Fernandez"
            };

            ViewBag.Fecha = DateTime.Now;

            return View(alumno);

        }

        public IActionResult MultiAlumno()
        {

            var listaAlumnos = InicializarAlumnos();

            return View(listaAlumnos);
        }

        private List<AlumnoModel> InicializarAlumnos()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               orderby n1, n2, a1 ascending
                               select new AlumnoModel() { Nombre = $"{n1} {n2} {a1}" };



            return listaAlumnos.ToList();


        }
    }
}
