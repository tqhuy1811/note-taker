using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using note_taker_server.IServices;
using note_taker_server.Models;
namespace note_taker_server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LanguageController : ControllerBase
	{
		private readonly IProgrammingLanguageService _lService;


		public LanguageController(IProgrammingLanguageService lService)
		{
			_lService = lService;
		}


		[HttpPost]
		public IActionResult CreateLanguage([FromBody] ProgrammingLanguage language)
		{
			_lService.saveProgrammingLanguage(language);
			return StatusCode(201);
		}

		[HttpGet]
		public async Task<ActionResult<List<ProgrammingLanguage>>> GetLanguages ()
		{
			return await _lService.GetLanguages();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguage(int id)
		{
			return await _lService.GetLanguage(id);
		}

  }
}
