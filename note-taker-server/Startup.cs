﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using note_taker_server.IServices;
using note_taker_server.Services;
using note_taker_server.Models;
using note_taker_server.Filters;
using AspNetCoreRateLimit;

namespace note_taker_server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.AddMemoryCache();
			services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
			services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
			services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
			services.AddMvc(config => {
				config.Filters.Add(new ValidateModelFilter());
				config.Filters.Add(new ExceptionFilter());
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddCors();
			services.AddScoped<IProgrammingLanguageService,ProgrammingLanguageService>();
			services.AddScoped<INoteService,NoteService>();
			services.AddScoped<ISearchService,SearchService>();
			services.AddDbContext<ApplicationContext>(options => 
				options.UseNpgsql(Configuration.GetConnectionString("NoteTakingDatabase")));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				// Include firebase host in production
				app.UseCors(builder => {
					builder.WithOrigins(Configuration["LocalHost"]).AllowAnyMethod().AllowAnyHeader();
				});
			}
			else
			{
				app.UseHsts();
			}
			app.UseIpRateLimiting();
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
