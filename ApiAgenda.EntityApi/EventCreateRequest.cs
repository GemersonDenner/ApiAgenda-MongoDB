using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAgenda.EntityApi
{
	public class EventCreateRequest
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Color Color { get; set; }
	}
}
