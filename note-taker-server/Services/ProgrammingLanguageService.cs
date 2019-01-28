using note_taker_server.Models;
using System;
using note_taker_server.Controllers;
using note_taker_server.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using note_taker_server.CustomExceptions;

namespace note_taker_server.Services
{
  public class ProgrammingLanguageService: IProgrammingLanguageService
  {
    private readonly ApplicationContext _context;
    public ProgrammingLanguageService(ApplicationContext context)
    {
      _context = context;
    }

    public async Task<ActionResult<ProgrammingLanguage>> GetLanguage(int id)
    {

	    var language = await _context.Languages.SingleOrDefaultAsync(l => l.LanguageId == id);
	    if(language != null)
	    {
		    return language;
	    }
	    throw new EntityNotExistException("Item not exist in the database");
    }

    public async Task<ActionResult<List<ProgrammingLanguage>>> GetLanguages()
    {
      return await _context.Languages.AsNoTracking().ToListAsync();
    }

    public async Task<IActionResult> DeleteLanguage(int languageId)
    {
      var language = await GetLanguage(languageId);
      _context.Languages.Remove(language.Value);
      _context.SaveChanges();
      return new NoContentResult();
    }

    public async Task<ActionResult<ProgrammingLanguage>> saveProgrammingLanguage(ProgrammingLanguage language)
    {
      try
      {
       await _context.Languages.AddAsync(language);
       _context.SaveChanges();
       return new CreatedResult(nameof(saveProgrammingLanguage), language);
      }
      catch(DbUpdateConcurrencyException ex)
      {
        Console.WriteLine(ex.Message);
      }
      return new StatusCodeResult(500);
    }

  }
}