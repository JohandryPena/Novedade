using Datos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Models;
using Modelo.Models.Sesion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Retefuente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeducioneController : ControllerBase
    {
        public DeducioneController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<DeducioneController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deduciones>>> Get()=> await new DeducioneData().GetAll();
        
        // POST api/<uvtController>
        [HttpPost("{id}")]
        public async Task<OkResult> Post(int id, [FromBody] Deduciones value)
        {
            await new DeducioneData().Insert(value,id);
            
            return Ok();
        }
    }
}
