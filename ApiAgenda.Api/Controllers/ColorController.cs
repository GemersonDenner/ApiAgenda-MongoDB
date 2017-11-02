using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiAgenda.DalMongo;
using ApiAgenda.DalMongo.Repositories;
using ApiAgenda.EntityApi;
using ApiAgenda.EntityMongo;
using AutoMapper;

namespace ApiAgenda.Api.Controllers
{
	[Route("api/Color")]
	public class ColorController : Controller
	{
		public IMapper Mapper { get; }

		public ColorRepository colorRepository { get; }

		public ColorController(AgendaMongoContext context, IMapper mapper)
		{
			colorRepository = new ColorRepository(context);
			Mapper = mapper;
		}
		// GET: api/Color
		[HttpGet("GetAll/")]
		public IEnumerable<EntityApi.Color> GetAll()
		{
			return Mapper.Map<IEnumerable<EntityApi.Color>>(colorRepository.GetAll());
		}

		// POST: api/Color
		[HttpPost("Create/")]
		public void Create([FromBody]EntityApi.ColorCreateRequest newColor)
		{
			var newColorMDB = Mapper.Map<EntityMongo.Color>(newColor);
			colorRepository.Include(newColorMDB);
		}

	}
}
