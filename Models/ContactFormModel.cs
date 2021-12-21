using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoralónElObrero.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "**Debe ingresar un nombre.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Debe ingresar un mensaje de 3 caracteres como minimo.")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "**Debe ingresar un telefono de contacto.")]
        [Phone(ErrorMessage = "ingrese un telefono valido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(200, MinimumLength = 30, ErrorMessage = "Debe ingresar un mensaje de 30 caracteres como minimo.")]
        public string Mensaje { get; set; }

    }
}
