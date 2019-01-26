using System;
using System.ComponentModel.DataAnnotations;

namespace note_taker_server.Models
{
	public class Note
	{

		public Note() {}

		public Note(string Title,string Content) 
		{ 
			this.Title = Title;
			this.Content = Content;
		}


		[Key]		
		public int NoteID { get; set; }
		[Required(ErrorMessage="Title is required")]
		public string Title { get; set; }
		[Required(ErrorMessage="Content is required")]
		public string Content { get; set; }

	}
}