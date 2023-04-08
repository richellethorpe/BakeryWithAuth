using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Bakery.Models

{
  public class Flavor
  {
    public int FlavorId { get; set; }

    [Required(ErrorMessage = "The flavor's name cannot be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The flavor's description cannot be empty")]
    public string Description { get; set; }

    public List<TreatFlavor> TreatFlavors { get; }
  }
} 