using System;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public abstract class ParentController : Controller
    {
        protected EscuelaContext _context { get; private set; }

        protected ParentController(EscuelaContext context)
        {
            if (context != null)
                _context = context;
            else
                throw new Exception("Dependency injection failed. EscuelaContext object is null");
        }

    }
}
