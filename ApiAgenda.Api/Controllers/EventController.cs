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
	[Route("api/Evento")]
	public class EventController : Controller
    {
		//[HttpGet]
		[HttpGet("{userId}", Name = "GetAll")]
		public IEnumerable<EntityApi.Event> GetAll(Guid userId)
        {
            return null;
		}

		//[HttpGet]
		[HttpGet("{userId}&{startDate}&{endDate}", Name = "GetWithRange")]
		public IEnumerable<EntityApi.Event> GetWithRange(Guid userId, DateTime startDate, DateTime endDate)
		{
			return null;
		}

		//[HttpGet]
		[HttpGet("{userId}&{startDate}", Name = "GetWithStart")]
		public IEnumerable<EntityApi.Event> GetWithStart(Guid userId, DateTime startDate)
		{
			return null;
		}

		// POST: api/Event
		[HttpPost]
        public void Create(Guid idUser, [FromBody]EntityApi.Event evento)
        {
        }

		// POST: api/Event
		[HttpPost("{idUser}")]
		public void Update(Guid idUser, [FromBody]EntityApi.Event evento)
		{
		}


		//[HttpDelete]
		// DELETE: api/ApiWithActions/5
		[HttpDelete("{idUser}&{idEvent}")]
		public void Delete(Guid idUser, Guid idEvent)
        {
        }
    }
}
