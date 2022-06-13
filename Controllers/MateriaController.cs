using Guia8Program_II.Models;
using System.Web.Mvc;

namespace Guia8Program_II.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            MantenimientoMateria Mmateria = new MantenimientoMateria();
            return View(Mmateria.ListarTodos());
        }

        // GET: Materia/Details/5
        public ActionResult Details(string id)
        {
            // Definimos un objeto de tipo "MantenimientoMateria"
            MantenimientoMateria Mmateria = new MantenimientoMateria();
            // Definimos un objeto de tipo "Materia"
            // Le asignamos el objeto que retorna el método "Consultar" en la tabla "Materias"
            Materia subject = Mmateria.Consultar(id);
            return View(subject);
        }


        public ActionResult Create()
        {
            return View();
        }
        // POST Materia/Create

        [HttpPost]
        // Ya no utilizamos el tipo "FormCollection", sino que la clase en la que almacenamos los datos
        public ActionResult Create(Materia subject)
        {
            try
            {
                if (ModelState.IsValid) // Si todas las validaciones se cumplen
                {
                    // Definimos un objeto de tipo "MantenimientoMateria"
                    MantenimientoMateria Mmateria = new MantenimientoMateria();
                    // Definimos un objeto de tipo "Materia"
                    Materia materia = new Materia
                    {
                        codMateria = subject.codMateria,
                        nombre = subject.nombre,
                        unidadValorativas = subject.unidadValorativas
                    };
                    // Llamamos al método "Ingresar"
                    Mmateria.Ingresar(materia);
                    // Invocamos acción "Index"
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: Materia/Edit/5
        public ActionResult Edit(string id)
        {

            MantenimientoMateria Mmateria = new MantenimientoMateria();

            Materia subject = Mmateria.Consultar(id);

            return View(subject);
        }
        // POST: Materia/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Materia subject)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    MantenimientoMateria Mmateria = new MantenimientoMateria();

                    Materia materia = new Materia
                    {
                        codMateria = id,
                        nombre = subject.nombre,
                        unidadValorativas = subject.unidadValorativas
                    };

                    Mmateria.Modificar(materia);

                    return RedirectToAction("Index");
                }
                else

                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: Materia/Delete/5
        public ActionResult Delete(string id)
        {
            MantenimientoMateria Mmateria = new MantenimientoMateria();

            Materia subject = Mmateria.Consultar(id);

            return View(subject);
        }

        // POST: Materia/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {

                MantenimientoMateria Mmateria = new MantenimientoMateria();

                Mmateria.Borrar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
