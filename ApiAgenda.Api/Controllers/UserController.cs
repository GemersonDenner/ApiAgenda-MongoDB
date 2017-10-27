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
	[Route("api/User")]
	public class UserController : Controller
    {

		//[HttpGet]
		// GET: api/User/5
		[HttpGet("{login}&{senha}", Name = "Get")]
		public EntityApi.User Get(string login, string senha)
        {
			return null;
        }
        
        // POST: api/User
        [HttpPost]
        public void Create([FromBody]EntityApi.User user)
        {
        }
    }
}
