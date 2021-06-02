using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class ValorTributario
    {

        public int IdRetefuente { get; set; }
        [Required]
        public decimal FechaRetefuente { get; set; }
        [Required]
        public decimal ValorRetefuente { get; set; }
        public int Estado { get; set; }
    }
}
