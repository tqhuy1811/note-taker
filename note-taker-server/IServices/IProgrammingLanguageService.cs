using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using note_taker_server.Models;
using note_taker_server.DAO;

namespace note_taker_server.IServices
{
  public interface IProgrammingLanguageService
  {
      Task<ActionResult> saveProgrammingLanguage(ProgrammingLanguage language);
      Task<ActionResult<ProgrammingLanguage>> GetLanguage(int id);

    

      Task<IActionResult> saveNote(NoteDAO noteDAO);

      Task<ActionResult<List<ProgrammingLanguage>>> GetLanguages();
  }
}