using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Models;
using api_brick.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // GET: api/Company
        [HttpGet]
        [Route("data")]
        public ActionResult Get()
        {
            CompanyData dt = CompanyDataService.get();
            if(dt is null)
            {
                return Ok(new { status = "failure", message ="No hay data disponible"});
            }
            return Ok(new { status = "success", data_company = dt });
        }

      

        // PUT: api/Company/nombre
        [HttpPut]
        [Route("data")]
        public ActionResult Put( string key,[FromBody] CompanyData data)
        {
           bool result =  CompanyDataService.update(data);
           if( !result)
            {
                return Ok(new { status = "failure", message = "Hubo un error al intentar guardar los datos. Contacte al administrador." });
            }
            
           return Ok(new { status = "success", message="Datos guardados exitosamente" });
        }

      
    }
}
