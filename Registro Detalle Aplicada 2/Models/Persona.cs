using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.Models
{
    public class Persona
    {
        [Key]
        [Required(ErrorMessage = "No debe de estar Vacío el campo 'PersonaId'")]   
        public int PersonaId { set; get; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Nombre'")]
        [MinLength(10, ErrorMessage = "El Nombres es muy corto.")]
        [MaxLength(50, ErrorMessage = "El nombre debe contener menos de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de Teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo Telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Cedula no puede estar vacío.")]
        [RegularExpression("^\\d{3}\\D?\\d{7}\\D?\\d$", ErrorMessage = "Por favor ingrese un No. de Cedula válido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Dirección'")]
        [MinLength(10, ErrorMessage = "La dirección bebe tener minimo (10 caracteres).")]
        [MaxLength(100, ErrorMessage = "La dirección debe tener Maximo (100 caracteres).")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]     
        public DateTime FechaNacimiento { get; set; }
        public decimal Balance { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0;
        }
    }
}
