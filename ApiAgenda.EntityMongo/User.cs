using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiAgenda.EntityMongo
{
	public class User
	{
		[BsonElement("Id")]
		public Guid Id { get; set; }

		[BsonElement("Login")]
		public string Login { get; set; }

		[BsonElement("Password")]
		public string Password { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("LastLogin")]
		public DateTime LastLogin { get; set; }

		[BsonElement("Events")]
		public List<Event> Events { get; set; }

		public User()
		{
			this.Id = Guid.NewGuid();
			Events = new List<Event>();
		}

		public User(string login, string senha)
		{
			this.Login = login;
			this.Password = senha;
		}

		public bool Founded()
		{
			return !string.IsNullOrEmpty(this.Login);
		}
	}
}
