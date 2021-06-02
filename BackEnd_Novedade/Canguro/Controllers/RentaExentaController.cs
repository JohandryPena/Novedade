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
    public class RentaExentaController : ControllerBase
    {
        public RentaExentaController(IConfiguration configuration)
        {
            Conexion.ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<RentaExentaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentaExenta>>> Get()=> await new RentaExentaData().GetAll();
        
        // POST api/<uvtController>
        [HttpPost("{id}")]
        public async Task<OkResult> Post(int id, [FromBody] RentaExenta value)
        {
            await new RentaExentaData().Insert(value,id);
            
            return Ok();
        }
    }
}
