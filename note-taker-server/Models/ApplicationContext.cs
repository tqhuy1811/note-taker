using System;
using Microsoft.EntityFrameworkCore;

namespace note_taker_server.Models
{
	public class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ProgrammingLanguage>().HasMany(l => l.Notes).WithOne();
		}
		
		

		public DbSet<ProgrammingLanguage> Languages { get; set; }
		public DbSet<Note> Notes { get; set; }
	}
}