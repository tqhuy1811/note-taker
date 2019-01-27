using note_taker_server.IServices;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using note_taker_server.DTO;
using note_taker_server.Models;
using System.Collections.Generic;

namespace note_taker_server.Services
{
  public class NoteService : INoteService
  {
    private readonly ApplicationContext _context;


    public NoteService(ApplicationContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> CreateNote(NoteDTO noteDTO)
    {
      _context.Notes.Add(new Note(Title:noteDTO.Title, Content:noteDTO.Content, LanguageId: noteDTO.LanguageID));
      await _context.SaveChangesAsync();
      return new StatusCodeResult(201);
    }

    public async Task<ActionResult<List<Note>>> GetNotes(int languageID, int skipItem)
    {
      return await _context.Notes.Where(n => n.LanguageId == languageID).Skip(skipItem).Take(5).AsNoTracking().ToListAsync();
    }
  }
}