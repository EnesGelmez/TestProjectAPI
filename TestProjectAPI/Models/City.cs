using System;
using System.Collections.Generic;

namespace TestProjectAPI.Models;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Plate { get; set; }
}
