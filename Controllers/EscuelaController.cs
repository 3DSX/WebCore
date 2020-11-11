using System;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
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

            ViewBag.halloween = "Voces";
            return View(escuela);
        }
    }
}
