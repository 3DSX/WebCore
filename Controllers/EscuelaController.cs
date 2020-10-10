using System;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();

            escuela.AñoFundacion = 1998;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Academia Kadic";
            return View(escuela);
        }
    }
}
