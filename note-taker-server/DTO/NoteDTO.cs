using System.ComponentModel.DataAnnotations;

namespace note_taker_server.DTO
{
  public class NoteDTO
  {
    [Required(ErrorMessage="Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage="Content is required")]
    public string Content { get; set; }


    [Required(ErrorMessage="Language Id is required")]
    public int LanguageID { get; set; }
  }
}