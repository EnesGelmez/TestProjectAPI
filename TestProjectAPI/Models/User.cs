using System;
using System.Collections.Generic;

namespace TestProjectAPI.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public string? Address { get; set; }

    public string Password { get; set; } = null!;
}
