using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Guia8Program_II.Models
{
    public class Alumnos
    {
       
        public string Carnet { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese su apellido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese su direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe de seleccionar su genero")]
        public string Sexo { get; set; }

        [Required(ErrorMessage= "Ingrese su numero de telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese un correo valido")]
        public string Email { get; set; }

    }
}