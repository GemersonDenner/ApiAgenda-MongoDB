using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAgenda.EntityApi
{
    public class Event
    {
		public Guid Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public bool IsCompleted { get; set; }

		public Color Color { get; set; }
	}
}
