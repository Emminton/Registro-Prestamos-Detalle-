using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.Models
{
    public class Mora
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 100, ErrorMessage = "El campo ID no puede ser cero o (mayor a 100).")]
        public int MoraId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Favor llenar el campo FECHA no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
         public virtual List<MorasDetalle> MoraDetalle { get; set; } 

        public Mora()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MoraDetalle = new List<MorasDetalle>();
        }

        public Mora(int moraId, DateTime fecha, decimal total)
        {
            MoraId = moraId;
            Fecha = fecha;
            Total = total;
        }
    }
}
