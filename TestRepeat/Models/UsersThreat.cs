using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public partial class UsersThreat
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdThreat { get; set; }

    public virtual Threat IdThreatNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
