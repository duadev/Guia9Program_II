using System.ComponentModel.DataAnnotations;

namespace Guia8Program_II.Models
{
    public class Materia
    {
        [Required(ErrorMessage ="Ingrese el codigo de materia")]
        [Display(Name="Codigo Materia")]
        public string codMateria { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la materia")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el la unida valorativa")]
        [Display(Name = "Unida Valorativa")]
        public int unidadValorativas { get; set; }
    }
}