using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using note_taker_server.IServices;
using note_taker_server.Models;
namespace note_taker_server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LanguageController : ControllerBase
	{
		private readonly IProgrammingLanguageService _lService;
		private readonly ApplicationContext _context;


		public LanguageController(IProgrammingLanguageService lService,ApplicationContext context)
		{
			_lService = lService;
			_context = context;
		}


		[HttpPost]
		public IActionResult CreateLanguage([FromBody] ProgrammingLanguage language)
		{
			_lService.saveProgrammingLanguage(language);
			return StatusCode(201);
		}

		[HttpGet]
		public async Task<ActionResult<List<ProgrammingLanguage>>> GetLanguages()
		{
			return await _lService.GetLanguages();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLanguage(int id)
		{
			return await _lService.DeleteLanguage(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguage(int id)
		{
			return await _lService.GetLanguage(id);
		}

  }
}
