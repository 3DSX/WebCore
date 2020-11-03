using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new AsignaturaModel
            {
                Nombre = "Física o Química"
            };

            ViewBag.Fecha = DateTime.Now;

            return View(asignatura);

        }

        public IActionResult MultiAsignatura()
        {

            List<AsignaturaModel> asignaturas = new List<AsignaturaModel>
            {
                    new AsignaturaModel() {Nombre = "Francés"},
                    new AsignaturaModel() {Nombre = "Español"},
                    new AsignaturaModel() {Nombre = "Inglés"},
                    new AsignaturaModel() {Nombre = "Química"},
                    new AsignaturaModel() {Nombre = "Matemáticas"},
                    new AsignaturaModel() {Nombre = "E.F"},
                    new AsignaturaModel() {Nombre = "Programación"}
            };

            return View(asignaturas);
        }
    }
}
