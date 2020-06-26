using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InterestCalc.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IWebHostEnvironment hostEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
			Environment.CurrentDirectory = hostEnvironment.ContentRootPath;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculo Juros Compostos API", Version = "v1" });
			});

			ConfigureIoC(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			ConfigureSwagger(app);

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		private void ConfigureIoC(IServiceCollection services)
		{
			services.AddScoped<ICompoundInterestService, CompoundInterestService>();
			services.AddScoped<IInterestRateService, InterestRateService>();
		}

		private void ConfigureSwagger(IApplicationBuilder app)
		{
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";

				c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "V1");
			});
		}
	}
}
