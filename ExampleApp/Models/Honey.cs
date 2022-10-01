using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace ExampleApp.Models;


public class Honey
	: object
{
	public long ID { get; set; }
	
	[Required]
	public int AvailableAmount { get; set; }
	
	[Required]
	public double Weight { get; set; }
	
	[Required]
	public double Price { get; set; }
	
	[Required]
	[RegularExpression(@"[A-Z]{1}[a-z\-]+",
		ErrorMessage = "Incorrect format for pollen source")]
	public string PollenSource { get; set; }
}
