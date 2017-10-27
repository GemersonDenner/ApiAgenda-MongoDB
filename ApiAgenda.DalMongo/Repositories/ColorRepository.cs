using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiAgenda.EntityMongo;
using MongoDB.Driver;

namespace ApiAgenda.DalMongo.Repositories
{
	public class ColorRepository : IRepository
	{
		public ColorRepository(AgendaMongoContext context) : base(context)
		{
		}

		public IEnumerable<Color> GetAll()
		{
			return _context.GetDatabase().GetCollection<Color>(typeof(Color).Name)
				.Find(x => true)
				.ToList();
		}

		public void Include(Color color)
		{
			_context.GetDatabase().GetCollection<Color>(typeof(Color).Name)
				.InsertOne(color);
		}
	}
}
