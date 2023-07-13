using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectAPI.Models;

public partial class Worker
{
    [ForeignKey("Id")]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Gender { get; set; }

    public string? Country { get; set; }

    public DateTime? BIRTHDATE { get; set; }

    public string? Tcno { get; set; }

    public Guid? Barcode { get; set; }
}
