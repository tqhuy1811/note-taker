using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.Models;


namespace note_taker_server.IServices
{
  public interface ISearchService
  {
    Task<ActionResult<List<ProgrammingLanguage>>> SearchLanguages(string languageName);
  }
}