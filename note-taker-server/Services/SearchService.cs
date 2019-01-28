using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using note_taker_server.Models;
using note_taker_server.IServices;


namespace note_taker_server.Services
{
  public class SearchService : ISearchService
  {

    private readonly ApplicationContext _context;


    public SearchService(ApplicationContext context)
    {
      _context = context;
    }


    public async Task<ActionResult<List<ProgrammingLanguage>>> SearchLanguages(string languageName)
    {
      var languages = from l in _context.Languages select l;
      if(!string.IsNullOrEmpty(languageName))
      {
        return await languages.Where(l => l.Title.ToLower().Contains(languageName.ToLower())).ToListAsync();
      }
      return new List<ProgrammingLanguage>();
    }
  }
}