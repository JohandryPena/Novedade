using Datos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Models;
using Modelo.Models.Sesion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retefuente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovedadController : ControllerBase
    {
        public NovedadController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<NovedadController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Novedad>>> Get()=> await new NovedadData().GetAll();
        
        // GET api/<uvtController>/5
        [HttpGet("{id:int:min(5)}")]
        public async Task<ActionResult<Novedad>> Get(int id)=> await new NovedadData().GetById(id);

        // GET api/<uvtController>/5
        [HttpGet("{Parametro}")]
        public async Task<ActionResult<IEnumerable<Novedad>>> Get(string Parametro) => await new NovedadData().GetByString(Parametro);

        [HttpGet("{FechaInicio:DateTime}/{FechaFin:DateTime}")]
        public async Task<ActionResult<IEnumerable<Novedad>>> Get(DateTime FechaInicio, DateTime FechaFin) => await new NovedadData().GetPorFecha(FechaInicio,FechaFin);
       
        
                // POST api/<uvtController>
        [HttpPost]
    
        public async Task<OkResult> Post([FromBody] Novedad value)
        {
            await new NovedadData().Insert(value);
            
            return Ok();
        }

        // PUT api/<uvtController>/5
        [HttpPut("{id}")]
    
        public async Task<OkResult> Put(int id, [FromBody] Novedad value)
        {
            await new NovedadData().Update(id, value);
            return Ok();
        }

        // DELETE api/<uvtController>/5
        [HttpDelete("{id}")]
        public async Task<OkResult> Delete(int id)
        {
            await new NovedadData().DeleteById(id);
            return Ok();
        }
    }
}
