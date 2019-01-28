using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using note_taker_server.Models;


namespace note_taker_server.IServices
{
  public interface IProgrammingLanguageService
  {
      Task<ActionResult<ProgrammingLanguage>> saveProgrammingLanguage(ProgrammingLanguage language);
      Task<ActionResult<ProgrammingLanguage>> GetLanguage(int id);

      Task<IActionResult> DeleteLanguage(int id); 
      Task<ActionResult<List<ProgrammingLanguage>>> GetLanguages();
  }
}