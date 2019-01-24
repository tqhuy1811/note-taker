using note_taker_server.Models;
using System;
using note_taker_server.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace note_taker_server.Services
{
  public class ProgrammingLanguageService: IProgrammingLanguageService
  {
    private readonly ApplicationContext _context;
    public ProgrammingLanguageService(ApplicationContext context)
    {
      _context = context;
    }

    public async Task<ProgrammingLanguage> GetLanguage(int id)
    {
      return await _context.Languages.FirstAsync(l => l.LanguageId == id);
    }

    public async Task<List<ProgrammingLanguage>> GetLanguages()
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