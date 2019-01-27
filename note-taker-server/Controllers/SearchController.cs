using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using note_taker_server.IServices;
using note_taker_server.Models;


namespace note_taker_server.Controllers
{
  [Route("/api/[controller]")]
  [ApiController]
  public class SearchController: ControllerBase
  {
    private readonly ISearchService _sService;

    public SearchController(ISearchService sService)
    {
      _sService = sService;
    }

    
    [HttpGet]
    public async Task<ActionResult<List<ProgrammingLanguage>>> SearchLanguages([FromQuery(Name = "languageName")] string languageName)
    {
      return await _sService.SearchLanguages(languageName);
    }
  }
}