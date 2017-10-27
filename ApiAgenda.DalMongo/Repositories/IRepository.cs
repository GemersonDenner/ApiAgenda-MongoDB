using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAgenda.DalMongo.Repositories
{
    public abstract class IRepository
    {
		public AgendaMongoContext _context;
		public IRepository(AgendaMongoContext context)
		{
			_context = context;
		}
	}
}
