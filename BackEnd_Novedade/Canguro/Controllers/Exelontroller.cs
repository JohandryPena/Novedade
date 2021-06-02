using Datos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Models;
using Modelo.Models.Sesion;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retefuente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExelController : ControllerBase
    {
      
        public ExelController(IConfiguration configuration)
        {           
          Conexion.ConnectionString =  ConfigurationExtensions.GetConnectionString(configuration, "ConnectionStrings");
        }
        // GET: api/<ExelController>
        [HttpGet]
        public ActionResult Get()
        {
           // ExcelData.get();
            return Ok();
        }

        // GET api/<uvtController>/5
        [HttpGet("{id:int:min(5)}")]
        public async Task<ActionResult<Concepto>> Get(int id) => await new ConceptoData().GetById(id);

    }
}
