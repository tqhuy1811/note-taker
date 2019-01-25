using note_taker_server.Models;
using System;
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



    public void saveProgrammingLanguage(ProgrammingLanguage language)
    {
      try
      {
       _context.Languages.Add(language);
       _context.SaveChanges();
      }
      catch(DbUpdateConcurrencyException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

  }
}