using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class AlumnoController : ParentController
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

            return View(_context.Alumnos);
        }


        public AlumnoController(EscuelaContext context) : base(context)
        {

        }
    }
}
