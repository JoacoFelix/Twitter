using System;
using System.Collections.Generic;

namespace Twitter.Models;

public partial class Mensaje
{
    public int IdUser { get; set; }

    public int IdChat { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public virtual Chat IdChatNavigation { get; set; } = null!;

    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
