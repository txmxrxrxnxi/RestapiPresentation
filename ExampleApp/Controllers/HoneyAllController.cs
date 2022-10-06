using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ExampleApp.Models;
using ExampleApp.Services;

namespace ExampleApp.Controllers;


[Route("/api/Honey")]
public class HoneyAllController
	: Controller
{
	private readonly IHoneyService _honeyService;

	public HoneyAllController(
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
	[ResponseCache(NoStore = true)]
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
}
