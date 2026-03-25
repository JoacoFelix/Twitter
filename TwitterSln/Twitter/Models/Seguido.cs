using System;
using System.Collections.Generic;

namespace Twitter.Models;

public partial class Seguido
{
    public int IdUserFollower { get; set; }

    public int IdUserFollowed { get; set; }

    public virtual Usuario IdUserFollowedNavigation { get; set; } = null!;

    public virtual Usuario IdUserFollowerNavigation { get; set; } = null!;
}
