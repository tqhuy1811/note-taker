using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace note_taker_server.Models
{
	public class ProgrammingLanguage
	{
		[Required(ErrorMessage="Title is required")]
		public string Title { get; set; }

		[Key]
		public int LanguageId { get; set; }
		
		public virtual List<Note> Notes { get; set; }
	}
}