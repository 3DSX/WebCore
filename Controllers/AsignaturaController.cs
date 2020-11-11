using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class AsignaturaController : ParentController
    {
        [Route("Asignatura/{id?}")]
        public IActionResult Index(string id)
        {
            ViewBag.Fecha = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(id))
            {
                var asignaturaChosen = from asignatura in _context.Asignaturas
                                       where asignatura.UniqueId == id
                                       select asignatura;

                if (asignaturaChosen.Count() != 0)
                    return View(asignaturaChosen.SingleOrDefault());
                else
                    return View(new AsignaturaModel { Nombre = "Not Found", UniqueId = "Not Found" });
            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas);
            }
        }

        public IActionResult MultiAsignatura()
        {

            return View(_context.Asignaturas);
        }


        public AsignaturaController(EscuelaContext context) : base(context)
        {

        }
    }
}
