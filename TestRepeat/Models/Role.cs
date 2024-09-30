using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Logined> Logineds { get; set; } = new List<Logined>();
}
