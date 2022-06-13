using Guia8Program_II.Models;
using System.Web.Mvc;

namespace Guia8Program_II.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        public ActionResult Index()
        {
            MantenimientoNota Mnota = new MantenimientoNota();
            return View(Mnota.ListarTodos());
        }

        // GET: Nota/Details/5
        public ActionResult Details(string id)
        {

            MantenimientoNota Mnota = new MantenimientoNota();

            Nota subject = Mnota.Consultar(id);
            return View(subject);
        }

        // POST ; Nota/ Create
       

        [HttpPost]
        public ActionResult Create(Nota note)
        {
            try
            {
                if (ModelState.IsValid) // Si todas las validaciones se cumplen
                {
                    // Definimos un objeto de tipo "MantenimientoMateria"
                    MantenimientoNota Mnota = new MantenimientoNota();
                    // Definimos un objeto de tipo "Materia"
                    Nota nota = new Nota
                    {
                        codMateria = note.codMateria,
                        carnetEstudiante = note.carnetEstudiante,
                        notaObtenida = note.notaObtenida,
                        estado = note.estado

                    };
                    // Llamamos al método "Ingresar"
                    Mnota.Ingresar(nota);
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

        [HttpPost]
        public ActionResult Create()
        {
            return View();

        }

        // GET: Nota/Edit/5
        public ActionResult Edit(string id)
        {
            MantenimientoNota Mnota = new MantenimientoNota();

            Nota subject = Mnota.Consultar(id);

            return View(subject);
        }

        // POST: Nota/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Nota subject)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    MantenimientoNota Mnota = new MantenimientoNota();

                    Nota nota = new Nota
                    {
                        codMateria = subject.codMateria,
                        carnetEstudiante = subject.carnetEstudiante,
                        notaObtenida = subject.notaObtenida,
                        estado = subject.estado
                    };

                    Mnota.Modificar(nota);

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

        // GET: Nota/Delete/5
        public ActionResult Delete(string id)
        {
            MantenimientoNota Mnota = new MantenimientoNota();

            Nota subject = Mnota.Consultar(id);

            return View(subject);
        }

        // POST: Nota/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {

                MantenimientoNota Mnota = new MantenimientoNota();

                Mnota.Borrar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
