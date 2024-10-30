using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public partial class Threat
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
