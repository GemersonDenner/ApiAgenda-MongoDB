using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiAgenda.EntityMongo
{
    public class Event
    {
		[BsonElement("Id")]
		public Guid Id { get; set; }

		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }

		[BsonElement("StartDate")]
		public DateTime StartDate { get; set; }

		[BsonElement("EndDate")]
		public DateTime EndDate { get; set; }

		[BsonElement("CreatedDate")]
		public DateTime CreatedDate { get; set; }

		[BsonElement("Completed")]
		public bool IsCompleted { get; set; }

		[BsonElement("Color")]
		public Color Color { get; set; }

		public Event()
		{
			this.Id = Guid.NewGuid();
		}
	}
}
