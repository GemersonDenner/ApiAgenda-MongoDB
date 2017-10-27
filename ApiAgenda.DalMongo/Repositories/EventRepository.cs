using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiAgenda.EntityMongo;
using MongoDB.Driver;

namespace ApiAgenda.DalMongo.Repositories
{
	public class EventRepository : IRepository
	{
		public EventRepository(AgendaMongoContext context) : base(context)
		{
		}

		public IEnumerable<Event> GetAll(Guid userId)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, userId);
			var proj = Builders<User>.Projection.Include(x => x.Events);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.Find(fd)
				.Project<Event>(proj)
				.ToList()
				.OrderBy(x => x.StartDate);
		}

		public IEnumerable<Event> Get(Guid userId, DateTime startDate, DateTime endDate)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, userId) & Builders<User>.Filter.Where(w => w.Events.Any(a => a.StartDate >= startDate && a.EndDate <= endDate));
			var proj = Builders<User>.Projection.Include(x => x.Events);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.Find(fd)
				.Project<Event>(proj)
				.ToList()
				.OrderBy(x => x.StartDate);
		}

		public IEnumerable<Event> Get(Guid userId, DateTime startDate)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, userId) & Builders<User>.Filter.Where(w => w.Events.Any(a => a.StartDate >= startDate));
			var proj = Builders<User>.Projection.Include(x => x.Events);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.Find(fd)
				.Project<Event>(proj)
				.ToList()
				.OrderBy(x => x.StartDate);
		}
	}
}
