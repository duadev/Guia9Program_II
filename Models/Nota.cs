using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guia8Program_II.Models
{
    public class Nota
    {
       

        [Display(Name = "Codigo Materia")]
        public string codMateria { get; set; }

        [Display(Name = "Carnet Estudiante")]
        public string carnetEstudiante { get; set; }

        [Display(Name = "Nota")]
        public string notaObtenida { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

    }
}