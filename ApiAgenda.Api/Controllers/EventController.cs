using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAgenda.DalMongo;
using ApiAgenda.EntityApi;
using ApiAgenda.EntityMongo;
using AutoMapper;
using ApiAgenda.DalMongo.Repositories;

namespace ApiAgenda.Api.Controllers
{
	[Route("api/Evento")]
	public class EventController : Controller
	{
		public IMapper Mapper { get; }

		public EventRepository eventRepository { get; }

		public EventController(AgendaMongoContext context, IMapper mapper)
		{
			eventRepository = new EventRepository(context);
			Mapper = mapper;
		}
		//[HttpGet]
		[HttpGet("GetAll/{userId}", Name = "GetAll")]
		public IEnumerable<EntityApi.Event> GetAll(Guid userId)
		{
			return Mapper.Map<IEnumerable<EntityApi.Event>>(eventRepository.GetAll(userId));
		}

		//[HttpGet]
		[HttpGet("GetWithRange/{userId}&{startDate}&{endDate}", Name = "GetWithRange")]
		public IEnumerable<EntityApi.Event> GetWithRange(Guid userId, DateTime startDate, DateTime endDate)
		{
			return Mapper.Map<IEnumerable<EntityApi.Event>>(eventRepository.Get(userId, startDate, endDate));
		}

		//[HttpGet]
		[HttpGet("GetWithStart/{userId}&{startDate}", Name = "GetWithStart")]
		public IEnumerable<EntityApi.Event> GetWithStart(Guid userId, DateTime startDate)
		{
			return Mapper.Map<IEnumerable<EntityApi.Event>>(eventRepository.Get(userId, startDate));
		}

		[HttpPost("Create/")]
		public void Create(Guid idUser, [FromBody]EntityApi.Event evento)
		{
			var eventoMDB = Mapper.Map<EntityMongo.Event>(evento);
			eventRepository.Insert(idUser, eventoMDB);
		}

		[HttpPost("Update/{idUser}", Name = "Update")]
		public void Update(Guid idUser, [FromBody]EntityApi.Event evento)
		{
			var eventoMDB = Mapper.Map<EntityMongo.Event>(evento);
			eventoMDB.Id = evento.Id;
			eventRepository.Update(idUser, eventoMDB);
		}

		[HttpDelete("Delete/{idUser}&{idEvent}")]
		public void Delete(Guid idUser, Guid idEvent)
		{
			eventRepository.Delete(idUser, idEvent);
		}
	}
}
