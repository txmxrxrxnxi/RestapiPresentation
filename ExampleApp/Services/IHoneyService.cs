using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using ExampleApp.Models;

namespace ExampleApp.Services;


public interface IHoneyService
{
	Task<IEnumerable<Honey>> ListAsync();
	Task<Honey?> FindAsync(long id);
	Task<IActionResult?> DeleteAsync(long id);
	Task<IActionResult> DeleteAsync();
	Task<IActionResult?> PutAsync(long id, Honey honey);
	Task<Honey?> PostAsync(Honey honey);
	Task<Honey?> PatchAsync(long id, JsonPatchDocument<Honey> patch);
}
