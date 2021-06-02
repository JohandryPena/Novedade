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
    public class ProcedimientoController : ControllerBase
    {
        public ProcedimientoController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<ProcedimientoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedimiento>>> Get()=> await new ProcedimientoData().GetAll();
        
        // GET api/<ProcedimientoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedimiento>> Get(int id)
        {
            var response = await  new ProcedimientoData().GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }
        // POST api/<ProcedimientoController>
        [HttpPost]
        public async void Post([FromBody] Procedimiento value)=> await new ProcedimientoData().Insert(value);
        
        // PUT api/<ProcedimientoController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Procedimiento value)=>await new ProcedimientoData().Update(id, value);

        // DELETE api/<ProcedimientoController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)=>await new ProcedimientoData().DeleteById(id);
    }
}
