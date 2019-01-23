using note_taker_server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace note_taker_server.IServices
{
  public interface IProgrammingLanguageService
  {
      void saveProgrammingLanguage(ProgrammingLanguage language);
      Task<ProgrammingLanguage> GetLanguage(int id);

      Task<List<ProgrammingLanguage>> GetLanguages();
  }
}