using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace note_taker_server.CustomExceptions
{
	public class EntityNotExistException: Exception
	{
		public string message { get; set; }
		public EntityNotExistException(string message)
		{
			this.message = message;
		}
	}
}