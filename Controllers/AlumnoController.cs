using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class AlumnoController : ParentController
    {
        [Route("Alumno/{id?}")]
        public IActionResult Index(string id)
        {
            ViewBag.Fecha = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumnoChosen = from alum in _context.Alumnos
                                   where alum.UniqueId == id
                                   select alum;

                if (alumnoChosen.Count() != 0)
                    return View(alumnoChosen.SingleOrDefault());
                else
                    return View(new AlumnoModel { Nombre = "Not Found", UniqueId = "Not Found" });
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }
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
