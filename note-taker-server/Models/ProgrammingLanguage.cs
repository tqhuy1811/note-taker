using System;
using System.Collections.Generic;

namespace note_taker_server.Models
{
	public class ProgrammingLanguage
	{
		public string Title { get; set; }
		public List<Note> Notes { get; set; }
	}
}