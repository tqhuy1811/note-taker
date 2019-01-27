using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.Helpers;
using note_taker_server.IServices;
using note_taker_server.Models;
using note_taker_server.DTO;


namespace note_taker_server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NoteController: ControllerBase
  {
    private readonly INoteService _nService;

    public NoteController(INoteService nService)
    {
      _nService = nService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] NoteDTO noteDTO)
    {
      return await _nService.CreateNote(noteDTO);
    }

    [HttpGet]
    public async Task<ActionResult<List<Note>>> GetNotes(
      [FromQuery(Name = "languageId")] int languageId,
      [FromQuery(Name = "skipItem")] int? skipItem
      )
    {
      return await _nService.GetNotes(languageId, Utils.CalculateSkipItems(skipItem));
    }

  }
}