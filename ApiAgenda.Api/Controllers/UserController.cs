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
	[Route("api/User")]
	public class UserController : Controller
	{
		public IMapper Mapper { get; }

		public UserRepository UserRepository { get; }

		public UserController(AgendaMongoContext context, IMapper mapper)
		{
			UserRepository = new UserRepository(context);
			Mapper = mapper;
		}

		//[HttpGet]
		// GET: api/User/5
		[HttpGet("Get/{login}&{senha}", Name = "Get")]
		public EntityApi.User Get(string login, string senha)
		{
			var user = new EntityMongo.User(login, senha);
			var foundedUser = UserRepository.Get(user);
			if (foundedUser.Founded())
			{
				UserRepository.UpdateLastLogin(foundedUser);
				return Mapper.Map<EntityApi.User>(foundedUser);
			}
			return new EntityApi.User();
		}

		// POST: api/User
		[HttpPost("Create/")]
		public void Create([FromBody]EntityApi.CreateUser user)
		{
			UserRepository.Insert(Mapper.Map<EntityMongo.User>(user));
		}
	}
}
