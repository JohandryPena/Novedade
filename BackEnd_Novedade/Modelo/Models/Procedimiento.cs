using System.ComponentModel.DataAnnotations;

namespace Modelo.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
