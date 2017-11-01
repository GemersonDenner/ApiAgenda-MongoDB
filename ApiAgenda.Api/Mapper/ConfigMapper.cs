using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAgenda.EntityApi;
using ApiAgenda.EntityMongo;

namespace ApiAgenda.Api.Mapper
{
	public class ConfigMapper : AutoMapper.Profile
	{
		public ConfigMapper()
		{
			CreateMap<EntityMongo.Color, EntityApi.Color>();
			CreateMap<EntityApi.Color, EntityMongo.Color>()
				.ForMember(
				x => x.Id,
				y => y.Ignore());

			CreateMap<EntityMongo.Event, EntityApi.Event>();
			CreateMap<EntityApi.Event, EntityMongo.Event>()
				.ForMember(
				x => x.Id,
				y => y.Ignore());

			CreateMap<EntityMongo.User, EntityApi.User>();
			CreateMap<EntityApi.User, EntityMongo.User>()
				.ForMember(
				x => x.Id,
				y => y.Ignore());

			CreateMap<EntityApi.CreateUser, EntityMongo.User>();
		}
	}
}
