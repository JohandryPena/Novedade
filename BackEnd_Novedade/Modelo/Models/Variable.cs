using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retefuente.Models
{
    public class Variable
    {
        public int Id { get; set; }
        public int RangoMin { get; set; }
        public int RangoMax { get; set; }
        public decimal Tarifa { get; set; }
        public string Descripcion { get; set; }
        public decimal UvtSumar { get; set; }
    }
}
