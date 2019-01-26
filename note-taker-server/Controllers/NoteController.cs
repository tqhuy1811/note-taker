using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.IServices;
using note_taker_server.Models;
using note_taker_server.DAO;


namespace note_taker_server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NoteController: ControllerBase
  {
    private readonly IProgrammingLanguageService _lService;
    private readonly ApplicationContext _context;

    public NoteController(IProgrammingLanguageService lService, ApplicationContext context)
    {
      _lService = lService;
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] NoteDAO noteDAO)
    {
      return await _lService.saveNote(noteDAO);
    }

    
  }
}