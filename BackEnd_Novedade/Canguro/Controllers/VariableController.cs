using Datos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retefuente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariableController : ControllerBase
    {
        public VariableController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<ProcedimientoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Variable>>> Get()=>await new VariableData().GetAll();
        
        // GET api/<uvtController>/5
        [HttpGet("{id:int:min(5)}")]
        public async Task<ActionResult<Models.Variable>> Get(int id)
        {
            var response = await new VariableData().GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }
        [HttpGet("{Parametro}")]
        public async Task<ActionResult<Models.Variable>> Get(string Parametro)
        {
            var response = await new VariableData().GetByString(Parametro);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/<uvtController>
        
        [HttpPost]
        public async  Task<OkResult> Post([FromBody] Models.Variable value)
        {
            await new VariableData().Insert(value);
            return Ok();
        }
        // PUT api/<uvtController>/5
        [HttpPut("{id}")]

        public async Task<OkResult> Put(int id, [FromBody] Models.Variable value)
        {
            await new VariableData().Update(id, value);
            return Ok();
        }

        
        // DELETE api/<uvtController>/5
        [HttpDelete("{id}")]
        public async Task<OkResult> Delete(int id)
        {
            await new VariableData().DeleteById(id);
            return Ok();
        }
    }
}
