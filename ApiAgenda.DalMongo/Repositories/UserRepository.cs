using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiAgenda.EntityMongo;
using MongoDB.Driver;

namespace ApiAgenda.DalMongo.Repositories
{
	public class UserRepository : IRepository
	{
		public UserRepository(AgendaMongoContext context) : base(context)
		{
		}

		public IEnumerable<User> GetAll()
		{
			var proj = Builders<User>.Projection.Exclude(x => x.Events);
			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.Find(x => true)
				.Project<User>(proj)
				.ToList();
		}

		public User Get(User user)
		{
			var proj = Builders<User>.Projection.Exclude(x => x.Events);

			return _context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.Find(x =>
					x.Login.Equals(user.Login)
					&& x.Password.Equals(user.Password))
				.Project<User>(proj).FirstOrDefault();
		}

		public void Insert(User user)
		{
			_context.GetDatabase().GetCollection<User>(typeof(User).Name)
				.InsertOne(user);
		}

		public void UpdateLastLogin(User user)
		{
			var fd = Builders<User>.Filter.Eq(x => x.Id, user.Id);
			var update = Builders<User>.Update.Set(x => x.LastLogin, DateTime.Now);
			_context.GetDatabase().GetCollection<User>(typeof(User).Name).UpdateOne(fd, update);
		}
	}

}
