using System;
using System.Collections.Generic;

namespace Modelo.Models
{
    public class Novedad
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime FechaNovedad { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdConcepto { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public decimal TipoConcepto { get; set; }
        public string NombreConcepto { get; set; }
        public string Operacion { get; set; }
        public Boolean liquidacion { get; set; }
        public int Estado { get; set; }
    }
}
