using Guia8Program_II.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guia8Program_II.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            MantenimientoAlumno Malumno = new MantenimientoAlumno();


            return View(Malumno.ListarAlumnos());
        }

       
        public ActionResult Eliminar(string carnet)
        {
            MantenimientoAlumno Malumno = new MantenimientoAlumno();
            Malumno.Eliminar(carnet);
            return RedirectToAction("Index");
        }


        public ActionResult Editar(string carnet)
        {
            MantenimientoAlumno Malumno = new MantenimientoAlumno();
            Alumnos student = Malumno.Consultar(carnet);

            return View(student);
        }

        [HttpPost]
        public ActionResult Editar(FormCollection collection)
        {
            MantenimientoAlumno Malumno = new MantenimientoAlumno();

            Alumnos student = new Alumnos
            {
                Carnet = collection["carnet"],
                Nombres = collection["nombre"],
                Apellidos = collection["apellido"],
                Direccion = collection["direccion"],
                Sexo = collection["sexo"],
                Telefono = collection["telefono"],
                Email = collection["correo"]
            };

            Malumno.Editar(student);
            return RedirectToAction("Index");

        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FormCollection collection)
        {
            try
            {
            
                if (ModelState.IsValid)
                {
                    MantenimientoAlumno Malumno = new MantenimientoAlumno();
            
                    Alumnos student = new Alumnos
                    {
                        Carnet = collection["carnet"],
                        Nombres = collection["nombre"],
                        Apellidos = collection["apellido"],
                        Direccion = collection["direccion"],
                        Sexo = collection["sexo"],
                        Telefono = collection["telefono"],
                        Email = collection["correo"]
            
                    };
            
                    Malumno.Agregar(student);
            
                    return RedirectToAction("Index");
                }
            
                return View();
            
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }   

        }


    }
}

