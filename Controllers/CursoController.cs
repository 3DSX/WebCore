using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class CursoController : ParentController
    {
        [Route("Curso/{id?}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var cursoChosen = from cur in _context.Cursos
                                  where cur.UniqueId == id
                                  select cur;

                if (cursoChosen.Count() != 0)
                    return View(cursoChosen.SingleOrDefault());
                else
                    return View(new CursoModel { Nombre = "Not Found", UniqueId = "Not Found" });
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }
        }

        public IActionResult MultiCurso()
        {

            return View(_context.Cursos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            var cursoEncontrado = from CursoModel curso in _context.Cursos
                                  where curso.UniqueId == id
                                  select curso;

            if (cursoEncontrado.Count() != 0)
            {

                return View(cursoEncontrado.SingleOrDefault());
            }
            else
            {
                TempData["Mensaje"] = "El curso que intentaste editar no existe";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(string id, CursoModel curso)
        {
            if (curso != null)
            {
                var cursoEncontrado = from CursoModel cur in _context.Cursos
                                      where cur.UniqueId == id
                                      select cur;

                if (cursoEncontrado.Count() != 0)
                {
                    if (ModelState.IsValid)
                    {
                        CursoModel cursObj = cursoEncontrado.SingleOrDefault();
                        curso.UniqueId = cursObj.UniqueId;
                        curso.EscuelaModelUniqueId = cursObj.EscuelaModelUniqueId;

                        _context.Remove(cursObj);
                        _context.Add(curso);
                        _context.SaveChanges();

                        TempData["Mensaje"] = $"El curso {curso.Nombre} ha sido editado en la DB";

                        return RedirectToAction("Index");
                    }
                    else
                        return View(cursoEncontrado.SingleOrDefault());

                }
                else
                {
                    TempData["Mensaje"] = "El curso que intentaste editar no existe";
                    return RedirectToAction("Index");
                }
            }
            else return RedirectToAction("Index");

        }

        public IActionResult Delete(string id)
        {
            var cursoEncontrado = from CursoModel curso in _context.Cursos
                                  where curso.UniqueId == id
                                  select curso;

            if (cursoEncontrado.Count() != 0)
            {
                CursoModel curso = cursoEncontrado.SingleOrDefault();

                Each<AlumnoModel>(_context.Alumnos, alumno =>
                {
                    if (alumno.CursoModelUniqueId == curso.UniqueId)
                    {
                        _context.Remove(alumno);
                    }
                });

                Each<AsignaturaModel>(_context.Asignaturas, asignatura =>
                {
                    if (asignatura.CursoModelUniqueId == curso.UniqueId)
                    {
                        _context.Remove(asignatura);
                    }
                });

                _context.Remove(curso);
                _context.SaveChanges();


                TempData["Mensaje"] = $"El curso {curso.Nombre} ha sido eliminado en la DB";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Mensaje"] = $"El curso que intentaste eliminar no existe";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(CursoModel curso)
        {
            if (ModelState.IsValid)
            {
                EscuelaModel escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaModelUniqueId = escuela.UniqueId;

                _context.Add(curso);
                _context.SaveChanges();

                ViewBag.ResultMessage = $"El curso {curso.Nombre} ha sido creado en la DB";

                return View("Index", curso);

            }
            else
            {
                return View();
            }
        }


        public CursoController(EscuelaContext context) : base(context)
        {

        }

        private static void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}
