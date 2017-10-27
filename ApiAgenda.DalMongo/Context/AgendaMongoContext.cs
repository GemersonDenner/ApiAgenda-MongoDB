using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAgenda.DalMongo
{
    public class AgendaMongoContext
    {
		protected readonly IMongoDatabase _database = null;

		//public AgendaMongoContext(DbContextOptions<Settings> settings)
		//{
		//	var client = new MongoClient(settings.Value.ConnectionString);
		//	if (client != null)
		//		_database = client.GetDatabase(settings.Value.Database);
		//}

		public AgendaMongoContext(string conn, string db)
		{
			var client = new MongoClient(conn);
			if (client != null)
				_database = client.GetDatabase(db);
		}

		public IMongoDatabase GetDatabase()
		{
			return _database;
		}
	}
}
