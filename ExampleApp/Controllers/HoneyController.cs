using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ExampleApp.Models;
using ExampleApp.Services;

namespace ExampleApp.Controllers;


[Route("/api/[controller]")]
public class HoneyController
	: Controller
{
	private readonly IHoneyService _honeyService;

	public HoneyController(
		IHoneyService honeyService)
	{
		this._honeyService = honeyService;
		return;
	}

	[HttpGet]
	public async Task<IEnumerable<Honey>> GetAllAsync()
	{
		IEnumerable<Honey> honeys = await this._honeyService.ListAsync();
		return (honeys);
	}

	[HttpDelete]
	public async Task<ActionResult> DeleteAsync()
	{
		await this._honeyService.DeleteAsync();
		return (NoContent());	
	}

	[HttpPost]
	public async Task<ActionResult> PostAsync(
		Honey honey)
	{
		await this._honeyService.PostAsync(honey);
		return Ok();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Honey>> GetAsync(
		long id)
	{
		Honey? honeys = await this._honeyService.FindAsync(id);
		return (honeys == null ? NotFound() : honeys);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteAsync(
		long id)
	{
		IActionResult? result = await this._honeyService.DeleteAsync(id);
		return (result == null ? NotFound() : NoContent());	
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> PutAsync(
		long id, Honey honey)
	{
		IActionResult? result = await this._honeyService.PutAsync(id, honey);
		return (result == null ? NotFound() : (ActionResult)result);	
	}


}
