using Datos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retefuente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public EmpleadoController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get() => await new EmpleadoData().GetAll(null);

        // GET api/<EmpleadoController>/5
        [HttpGet("{Parametro}")]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get(string Parametro)
        {
            if (Parametro is null)
            {
                throw new System.ArgumentNullException(nameof(Parametro));
            }

            return await new EmpleadoData().GetAll(Parametro);
        }

        [HttpGet("{id:int:min(5)}")]
        public async Task<ActionResult<Empleado>> Get(int id) => await new EmpleadoData().GetById(id);
    }
}
