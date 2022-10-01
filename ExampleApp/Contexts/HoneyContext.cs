using Microsoft.EntityFrameworkCore;
using ExampleApp.Models;

namespace ExampleApp.Contexts;


public class HoneyContext
	: DbContext
{
	public DbSet<Honey> Honeys { get; set; } = null!;

	public HoneyContext(
			DbContextOptions<HoneyContext> options)
		: base(options)
	{
		return;
	}
}