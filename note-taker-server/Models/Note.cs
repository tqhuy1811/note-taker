using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace note_taker_server.Models
{
	public class Note
	{

		public Note() {}

		public Note(string Title,string Content, int LanguageId) 
		{ 
			this.Title = Title;
			this.Content = Content;
			this.LanguageId = LanguageId;
		}


		[Key]		
		public int NoteID { get; set; }
		[Required(ErrorMessage="Title is required")]
		public string Title { get; set; }
		[Required(ErrorMessage="Content is required")]
		public string Content { get; set; }

		[ForeignKey("LanguageId")]
		public ProgrammingLanguage language { get; set ;}


		public int LanguageId { get; set; }

	}
}