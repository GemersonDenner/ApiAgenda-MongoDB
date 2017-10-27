using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAgenda.DalMongo;
using ApiAgenda.EntityApi;
using ApiAgenda.EntityMongo;


namespace ApiAgenda.Api.Controllers
{
	[Route("api/Color")]
	public class ColorController : Controller
    {
        // GET: api/Color
        [HttpGet]
        public IEnumerable<EntityApi.Color> GetAll()
        {
            return null;
		}
        
        // POST: api/Color
        [HttpPost]
        public void Create([FromBody]EntityApi.Color newColor)
        {
        }
        
    }
}
