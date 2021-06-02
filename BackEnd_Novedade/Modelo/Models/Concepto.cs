using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Concepto
    {
        public decimal Id { get; set; }
        public decimal TipoConcepto { get; set; }
        public string Nombre { get; set; }
        public string Operacion { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Cantidad { get; set; }
        public bool Valor { get; set; }
        public bool PorHora { get; set; }
    }
}
