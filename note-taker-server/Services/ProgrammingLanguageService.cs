using note_taker_server.Models;
using System;
using System.Linq;
using note_taker_server.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.DTO;
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
      await _context.SaveChangesAsync();
      return new NoContentResult();
    }

    public async Task<ActionResult> saveProgrammingLanguage(ProgrammingLanguage language)
    {
      try
      {
       await _context.Languages.AddAsync(language);
       _context.SaveChanges();
       return new StatusCodeResult(201);
      }
      catch(DbUpdateConcurrencyException ex)
      {
        Console.WriteLine(ex.Message);
      }
      return new StatusCodeResult(500);
    }

  }
}