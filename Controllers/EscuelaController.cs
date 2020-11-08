using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class EscuelaController : ParentController
    {
        public IActionResult Index()
        {
            ViewBag.halloween = "La Monja";

            return View(_context.Escuelas.FirstOrDefault());
        }

        public EscuelaController(EscuelaContext context) : base(context)
        {

        }

    }
}
