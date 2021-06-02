using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Empleado
    {

        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public string Cedula { get; set; }
    }
}
