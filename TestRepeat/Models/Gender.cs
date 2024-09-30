using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
