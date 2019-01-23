using System;
using Microsoft.EntityFrameworkCore;

namespace note_taker_server.Models
{
	public class ApplicationContext: DbContext
	{
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        { }

        public DbSet<ProgrammingLanguage> Languages { get; set; }
        public DbSet<Note> Notes { get; set; }
	}
}