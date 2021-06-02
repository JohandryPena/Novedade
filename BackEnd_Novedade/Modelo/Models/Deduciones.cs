using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Deduciones
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string documento { get; set; }
        public decimal InteresVivienda { get; set; }
        public decimal Prepagada { get; set; }
        public decimal Dependiente { get; set; }
        public decimal Total { get; set; }
    }
}
