using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.Models;
using note_taker_server.DTO;


namespace note_taker_server.IServices
{
  public interface INoteService
  { 
    Task<IActionResult> CreateNote(NoteDTO noteDTO);
    Task<ActionResult<List<Note>>> GetNotes(int languageId,int skipItem);
  }
}

