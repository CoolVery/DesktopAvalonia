using System;
using System.Collections.Generic;

namespace TestRepeat.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public int IdGender { get; set; }

    public byte[]? ImgUser { get; set; }

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual Logined IdUserNavigation { get; set; } = null!;
}
