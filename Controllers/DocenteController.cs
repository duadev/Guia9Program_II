using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guia8Program_II.Models;

namespace Guia8Program_II.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {

            MantenimientoDocente Mdocente = new MantenimientoDocente();
           
            return View(Mdocente.ListarTodos());
        }

       
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FormCollection collection)
        {
            MantenimientoDocente Mdocente = new MantenimientoDocente();

            Docente teacher = new Docente
            {
                codigoDocente = collection["codigoDocente"],
                nombre = collection["nombre"],
                apellido = collection["apellido"],
                especialidad = collection["especialidad"],
                titulo = collection["titulo"],

            };

            Mdocente.Ingresar(teacher);
            return RedirectToAction("Index");
        }


        public ActionResult Eliminar(string codigoDocente)
        {
            MantenimientoDocente Mdocente = new MantenimientoDocente();
            Mdocente.Borrar(codigoDocente);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(string codigoDocente)
        {
            MantenimientoDocente Mdocente = new MantenimientoDocente();
            Docente teacher = Mdocente.Consultar(codigoDocente);

            return View(teacher);
        }

        [HttpPost]

        public ActionResult Editar(FormCollection collection)
        {
            MantenimientoDocente Mdocente = new MantenimientoDocente();
            Docente teacher = new Docente
            {
                codigoDocente = collection["codigoDocente"],
                nombre = collection["nombre"],
                apellido = collection["apellido"],
                especialidad = collection["especialidad"],
                titulo = collection["titulo"],
            };

            Mdocente.Editar(teacher);
            return RedirectToAction("Index");
        }
    }
}