using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Bakery.Models

{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "The treat's name cannot be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The treat's description cannot be empty")]
    public string Description { get; set; }


    public List<TreatFlavor> JoinEntity { get; }
  }
}