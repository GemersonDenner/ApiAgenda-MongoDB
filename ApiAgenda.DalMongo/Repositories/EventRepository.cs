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
				.Find(fd).FirstOrDefault().Events;
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

		public bool Insert(Guid userId, Event evento)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, userId);
			//var update = Builders<User>.Update.Push("")
			var update = Builders<User>.Update.Push(s => s.Events, evento);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.UpdateOne(fd, update).ModifiedCount > 0;
		}

		public bool Update(Guid userId, Event evento)
		{

			var fd = Builders<User>.Filter.Where(x => x.Id.Equals(userId) && x.Events.Any(a => a.Id.Equals(evento.Id)));
			var update = Builders<User>.Update.Set(x => x.Events[-1], evento);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.UpdateOne(fd, update).ModifiedCount > 0;
		}

		public void Delete(Guid userId, Guid idEvent)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, userId);
			var update = Builders<User>.Update.PullFilter(x => x.Events, e => e.Id.Equals(idEvent));
			_context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.FindOneAndUpdate(fd, update);
		}
	}
}
