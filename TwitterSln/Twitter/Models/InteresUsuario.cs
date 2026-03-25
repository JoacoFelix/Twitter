using System;
using System.Collections.Generic;

namespace Twitter.Models;

public partial class InteresUsuario
{
    public int IdInteres { get; set; }

    public int IdUser { get; set; }

    public virtual Interes IdInteresNavigation { get; set; } = null!;

    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
