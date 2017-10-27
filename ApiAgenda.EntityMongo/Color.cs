using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiAgenda.EntityMongo
{
    public class Color
    {
		[BsonElement("Id")]
		public Guid Id { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }

		[BsonElement("CssClass")]
		public string CssClass { get; set; }

		public Color()
		{
			this.Id = Guid.NewGuid();
		}

	}
}
