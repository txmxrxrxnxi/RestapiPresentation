using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using ExampleApp.Contexts;
using ExampleApp.Services;
using ExampleApp.Supplements;

namespace ExampleApp;


public static class Program
{
	private static WebApplicationBuilder? Builder;
	private static WebApplication? App;

	public static void Main(
		string[] args)
	{
		Program.Builder = WebApplication.CreateBuilder(
			args: args);

		Program.Builder.Services.AddEndpointsApiExplorer();
		Program.Builder.Services.AddControllers(
			configure: (MvcOptions options) =>
			{
				options.InputFormatters.Insert(
					index: 0, 
					item: JsonPatchInputFormatter.GetJsonPatchInputFormatter());
				return;
			});
		Program.Builder.Services.AddSwaggerGen();
		Program.Builder.Services.AddScoped<IHoneyService, HoneyService>();
		Program.Builder.Services.AddDbContext<HoneyContext>(
			optionsAction: (DbContextOptionsBuilder options) => 
			{
				options.UseNpgsql(File.ReadAllText("dbconf"));
				return;
			});

		Program.App = Program.Builder.Build();

		if (Program.App.Environment.IsDevelopment() == true)
		{
			Program.App.UseSwagger();
			Program.App.UseSwaggerUI();
		}

		Program.App.UseHttpsRedirection();
		Program.App.UseAuthorization();
		Program.App.MapControllers();

		Program.App.Run();

		return;
	}
}
