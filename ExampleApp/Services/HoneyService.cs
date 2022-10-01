using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using ExampleApp.Contexts;
using ExampleApp.Models;

namespace ExampleApp.Services;


public class HoneyService
	: IHoneyService
{
	private readonly HoneyContext _honeyContext;

	public HoneyService(
		HoneyContext honeyContext)
	{
		this._honeyContext = honeyContext;
		return;
	}

	public async Task<IEnumerable<Honey>> ListAsync()
	{
		List<Honey>? honeys = await this._honeyContext.Honeys.ToListAsync();
		return (honeys.AsEnumerable());
	}

	public async Task<Honey?> FindAsync(
		long id)
	{
		Honey? honey = await _honeyContext.Honeys.FindAsync(id);
		return (honey);
	}

	public async Task<Honey?> PostAsync(
		Honey honey)
	{
		this._honeyContext.Honeys.Add(honey);
		await this._honeyContext.SaveChangesAsync();
		return (honey);
	}

	public async Task<IActionResult?> DeleteAsync(
		long id)
	{
		Honey? honey = await this._honeyContext.Honeys.FindAsync(id);

		if (honey == null)
		{
			return (null);
		}

		this._honeyContext.Honeys.Remove(honey);
		await this._honeyContext.SaveChangesAsync();
		return (new NoContentResult());
	}

	public async Task<IActionResult> DeleteAsync()
	{
		List<Honey>? honeys = await this._honeyContext.Honeys.ToListAsync();

		honeys.ForEach(
			action: (Honey honey) => 
			{
				this._honeyContext.Honeys.Remove(honey);
				return;
			});

		await this._honeyContext.SaveChangesAsync();
		return (new NoContentResult());
	}

	public async Task<IActionResult?> PutAsync(
		long id,
		Honey honey)
	{
		if (id != honey.ID)
		{
			return (new BadRequestObjectResult(
				error: $"Resources' ID mismatch: {id} and {honey.ID}"));
		}

		this._honeyContext.Entry(honey).State = EntityState.Modified;

		try
		{
			await this._honeyContext.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			Honey? found = await this._honeyContext.Honeys.FindAsync(id);
			if (found == null)
			{
				return (null);
			}
			else
			{
				throw;
			}
		}

		return (new NoContentResult());
	}
}
