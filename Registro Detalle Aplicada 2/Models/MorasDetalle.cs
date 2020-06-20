using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.Models
{
    public class MorasDetalle
    {
        [Key]
        public int MoraDetalleId { get; set; }       
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Valor { get; set; }
        public MorasDetalle() 
        {
            MoraDetalleId = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public MorasDetalle( int moraId, int prestamoId, decimal valor)
        {
            MoraDetalleId = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}
