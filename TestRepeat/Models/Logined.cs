using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public record Logined
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
