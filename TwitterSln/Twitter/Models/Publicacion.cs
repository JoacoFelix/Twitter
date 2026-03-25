using System;
using System.Collections.Generic;

namespace Twitter.Models;

public partial class Publicacion
{
    public int IdPublicacion { get; set; }

    public int IdUser { get; set; }

    public string Texto { get; set; } = null!;

    public long Likes { get; set; }

    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
