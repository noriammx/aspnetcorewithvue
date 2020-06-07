using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APSNetCoreMVCWithVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public List<Persona> Get()
        {
            List<Persona> lst = null;

            using (Models.vueContext db= new Models.vueContext())
            {
                lst = (from data in db.Persona
                       select new Persona
                       {
                           Nombre = data.Nombre,
                           Apellido = data.Apellido,
                       }
                ).ToList();


            }

            return lst;
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}