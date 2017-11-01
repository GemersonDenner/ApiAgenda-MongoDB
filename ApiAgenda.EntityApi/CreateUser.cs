using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAgenda.EntityApi
{
    public class CreateUser
    {
		public string Login { get; set; }

		public string Password { get; set; }

		public string Name { get; set; }
	}
}
