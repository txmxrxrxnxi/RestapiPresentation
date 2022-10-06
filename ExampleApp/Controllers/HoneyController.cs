using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ExampleApp.Models;
using ExampleApp.Services;

namespace ExampleApp.Controllers;


[ResponseCache(NoStore = true)]
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

	[HttpGet("{id}")]
	public async Task<ActionResult<Honey>> GetAsync(
		[FromRoute] long id)
	{
		Honey? honeys = await this._honeyService.FindAsync(id);
		return (honeys == null ? NotFound() : honeys);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteAsync(
		[FromRoute] long id)
	{
		IActionResult? result = await this._honeyService.DeleteAsync(id);
		return (result == null ? NotFound() : NoContent());	
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> PutAsync(
		[FromRoute] long id, 
		[FromBody] Honey honey)
	{
		IActionResult? result = await this._honeyService.PutAsync(id, honey);
		return (result == null ? NotFound() : (ActionResult)result);
	}
}
